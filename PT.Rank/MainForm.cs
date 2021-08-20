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

namespace PT.Rank
{
	public partial class MainForm : Form
	{
		public string UserInfo
		{
			get
			{
				return Path.Combine(txtServerPath.Text, @"DataServer\UserInfo\");
			}
		}

		public MainForm()
		{
			InitializeComponent();
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
						MessageBox.Show("Sucesso!");
					}
				}
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
			var str = string.Format("INSERT INTO [dbo].[{0}] (ID, Name, Job, Level, Exp) VALUES(?, ?, ?, ?, ?)", txtSqlTable.Text);

			txtSqlQuery.Text = str;
		}

		private void btnRankGo_Click(object sender, EventArgs e)
		{
			if(tmRank.Enabled)
			{
				tmRank.Stop();
			}

			tmRank.Interval = (int)nudRankTimer.Value * 1000;

			tmRank.Start();
		}

		private void tmRank_Tick(object sender, EventArgs e)
		{
			try
			{

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}
