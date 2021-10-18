using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Data.Common;
using System.Globalization;

namespace PT.Rank
{
	using Engine;
	using Helper;

	public partial class MainForm : Form
	{
		public string UserInfo
		{
			get
			{
				return Path.Combine(txtServerPath.Text, @"DataServer\UserInfo\");
			}
		}

		public string UserData
		{
			get
			{
				return Path.Combine(txtServerPath.Text, @"DataServer\UserData\");
			}
		}

		public string GameServer
		{
			get
			{
				return Path.Combine(txtServerPath.Text, @"GameServer\");
			}
		}

		private SqlConnectionStringBuilder SqlDSN = null;

		private int _rankTimerTicks = 0;

		private DataTable _rankTable = null;

		private BindingList<Loot> _loots = null;

		public MainForm()
		{
			InitializeComponent();

#if !DEBUG
			foreach(var c in tpDrop.Controls)
			{
				(c as Control).Enabled = false;
			}
#endif

			_rankTable = new DataTable
			{
				Locale = CultureInfo.InvariantCulture
			};

			dgvRank.ReadOnly = true;
			dgvRank.AutoResizeColumns(
				DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

			_loots = new BindingList<Loot>
			{
				AllowEdit = true,
				AllowNew = true,
				AllowRemove = true
			};

			dgvDrops.DataSource = _loots;
			dgvDrops.AutoResizeColumns(
				DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
		}

		private void btnTryConnection_Click(object sender, EventArgs e)
		{
			gbSqlSettings.Enabled = false;

			try
			{
				var builder = new SqlConnectionStringBuilder
				{
					DataSource = txtSqlInstance.Text,
					UserID = txtSqlUser.Text,
					Password = txtSqlPwd.Text,
					InitialCatalog = txtSqlDB.Text,
					ConnectTimeout = 30
				};

				using(var connection = new SqlConnection(builder.ConnectionString))
				{
					connection.Open();

					if(connection.State == ConnectionState.Open)
					{
						SqlDSN = builder;

						MessageBox.Show("Sucesso!");
					}
				}

				var str = string.Format("INSERT INTO [dbo].[{0}] (ID, Name, Classe, Level, Exp) VALUES(@ID, @Name, @Classe, @Level, @Exp)", txtSqlTable.Text);

				txtSqlQuery.Text = str;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			gbSqlSettings.Enabled = true;
		}

		private void ckbShowPwd_CheckedChanged(object sender, EventArgs e)
		{
			txtSqlPwd.UseSystemPasswordChar = !ckbShowPwd.Checked;
		}

		private void btnServerPath_Click(object sender, EventArgs e)
		{
			try
			{
				var fbd = new FolderBrowserDialog()
				{
					RootFolder = Environment.SpecialFolder.Startup,
					Description = "Diretório do Servidor:"
				};

				if(fbd.ShowDialog() == DialogResult.OK)
				{
					txtServerPath.Text = fbd.SelectedPath;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void txtSqlTable_TextChanged(object sender, EventArgs e)
		{
			var str = string.Format("INSERT INTO [dbo].[{0}] (ID, Name, Classe, Level, Exp) VALUES(@ID, @Name, @Classe, @Level, @Exp)", txtSqlTable.Text);

			txtSqlQuery.Text = str;
		}

		private void nudRankTimer_ValueChanged(object sender, EventArgs e)
		{
			_rankTimerTicks = 0;
		}

		private void btnRankGo_Click(object sender, EventArgs e)
		{
			if(SqlDSN == null)
			{
				MessageBox.Show("Primeiro configure as credenciais do sql!");

				return;
			}

			if(_rankTimerTicks == 0)
			{
				lbRankLog.Items.Add("Iniciando atualização!");

				bgWorkerRank.RunWorkerAsync();
			}

			if(tmRank.Enabled)
			{
				tmRank.Stop();
			}

			tmRank.Start();
		}

		private void tmRank_Tick(object sender, EventArgs e)
		{
			if(!bgWorkerRank.IsBusy)
			{
				_rankTimerTicks++;

				var time = (int)nudRankTimer.Value;

				if(_rankTimerTicks <= time)
				{
					lbRankLog.Items.RemoveAt(lbRankLog.Items.Count - 1);

					lbRankLog.Items.Add($"Atualiza em: {time - _rankTimerTicks} segundos.");

					return;
				}

				_rankTimerTicks = 0;

				lbRankLog.Items.Clear();

				lbRankLog.Items.Add("Iniciando atualização!");

				bgWorkerRank.RunWorkerAsync();
			}
		}

		private void bgWorkerRank_DoWork(object sender, DoWorkEventArgs e)
		{
			ProcessFiles();
		}

		private void ProcessFiles()
		{
			try
			{
				if(!Directory.Exists(UserData))
				{
					throw new DirectoryNotFoundException();
				}

				var files = Directory.GetFiles(UserData, "*.dat", SearchOption.AllDirectories);

				using(var connection = new SqlConnection(SqlDSN.ConnectionString))
				{
					connection.Open();

					using(var command = new SqlCommand($"TRUNCATE TABLE {txtSqlTable.Text}", connection))
					{
						if(connection.State == ConnectionState.Open)
						{
							command.ExecuteNonQuery();
						}
					}

					foreach(var file in files)
					{
						ProcessFile(file, connection);
					}

					FilldgvRank(connection);

					lbRankLog.SelectedIndex = lbRankLog.Items.Count - 1;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!");

				return;
			}
		}

		private void ProcessFile(string fileName, SqlConnection connection)
		{
			try
			{
				if(connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				var ch = new RankEntry(fileName);

				using(var command = new SqlCommand(txtSqlQuery.Text, connection))
				{
					AddParams(command);
					FillParams(command, ch);

					command.ExecuteNonQuery();
				}

				lbRankLog.Items.Add(ch.ToString());
			}
			catch(Exception ex)
			{
				lbRankLog.Items.Add(ex.Message);

				using(var sw = new StreamWriter("Rank-Errors.log"))
				{
					sw.WriteLine($"Arquivo: {fileName}, Erro: {ex.Message}");
				}
			}
		}

		private void AddParams(SqlCommand command)
		{
			command.Parameters.Add("@ID", SqlDbType.VarChar, 32);
			command.Parameters.Add("@Name", SqlDbType.VarChar, 32);
			command.Parameters.Add("@Classe", SqlDbType.Int);
			command.Parameters.Add("@Level", SqlDbType.Int);
			command.Parameters.Add("@Exp", SqlDbType.Int);
		}

		private void FillParams(SqlCommand command, RankEntry rl)
		{
			command.Parameters["@ID"].Value = rl.Id;
			command.Parameters["@Name"].Value = rl.Name;
			command.Parameters["@Classe"].Value = rl.Job;
			command.Parameters["@Level"].Value = rl.Level;
			command.Parameters["@Exp"].Value = rl.Exp;
		}

		private void FilldgvRank(SqlConnection connection)
		{
			try
			{
				if(connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				using(var adapter = new SqlDataAdapter($"SELECT * FROM [dbo].[{txtSqlTable.Text}] WHERE ID NOT IN (SELECT accountId FROM accountdb..GameMasters) ORDER BY Level DESC, Exp DESC", connection))
{
					var commandBuilder = new SqlCommandBuilder(adapter);

					_rankTable.Clear();

					adapter.Fill(_rankTable);
					
					dgvRank.DataSource = _rankTable;
				}
			}
			catch(Exception ex)
			{
				lbRankLog.Items.Add(ex.Message);

				using(var sw = new StreamWriter("Rank-Errors.log"))
				{
					sw.WriteLine($"Erro: {ex.Message}");
				}
			}
		}


// Tests, drop editor


		private void tpDrop_Enter(object sender, EventArgs e)
		{
			ListMonsterFiles(lbDropMonsters);
		}

		private void lbDropMonsters_SelectedIndexChanged(object sender, EventArgs e)
		{
			var monsterPath = Path.Combine(GameServer, @"Monster\");

			var selection = lbDropMonsters.SelectedItem.ToString();

			var file = Path.Combine(monsterPath, selection);

			ListMonstersDrops(file);
		}

		private void btnDropSave_Click(object sender, EventArgs e)
		{

		}

		void ListMonsterFiles(ListBox listBox)
		{
			var monsterPath = Path.Combine(GameServer, @"Monster\");

			var monsters = Directory.GetFiles(monsterPath, "*.inf");

			listBox.Items.Clear();

			foreach(var file in monsters)
			{
				var fileName = Path.GetFileName(file);

				listBox.Items.Add(fileName);
			}
		}

		private void ListMonstersDrops(string file)
		{
			int line = 0;
			string text = string.Empty;

			try
			{
				_loots.Clear();

				var sb = new StringBuilder();

				sb.AppendLine(file);

				using(var sr = new StreamReader(file, Encoding.Default))
				{
					while(!sr.EndOfStream)
					{
						++line;

						int position = 0;

						string buffer = sr.ReadLine();
						string keyword = Utils.GetWord(buffer, ref position);

						text = buffer;

						if(string.Compare(keyword, Monster.Keywords.FallItemMax) == 0)
						{
							var dropNumber = Utils.ParseInteger(buffer, ref position);

							nudDropNumber.Value = dropNumber;
						}
						else if(string.Compare(keyword, Monster.Keywords.FallItems) == 0)
						{
							var loot = Utils.ParseLoot(buffer, ref position);

							if(loot.HasValue && !loot.Value.Nothing)
							{
								_loots.Add(loot.Value);

								sb.AppendLine();
								sb.AppendLine(buffer);
								sb.AppendLine(loot.Value.ToString());
							}
						}
					}
				}

				using(var sw = new StreamWriter("loot.log"))
				{
					sw.Write(sb);
				}
			}
			catch(Exception ex)
			{
				using(var sw = new StreamWriter("error.log"))
				{
					var error = Utils.FormatErrorMessage(ex, file, line, text);

					sw.WriteLine(error);
				}
			}
			finally
			{
				//ReloadDgvDrops();
			}
		}

		private void ReloadDgvDrops()
		{
			try
			{
				var dt = new DataTable();

				dt.Columns.Add("Rate");
				dt.Columns.Add("Money");
				dt.Columns.Add("Coins");
				dt.Columns.Add("Items");
				dt.Columns.Add("Nothing");


				foreach(var loot in _loots)
				{
					dt.Rows.Add();
				}

				dgvDrops.DataSource = dt;
			}
			catch(Exception)
			{
				throw;
			}
		}
	}
}
