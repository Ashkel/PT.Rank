
namespace PT.Rank
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpSettings = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnServerPath = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtServerPath = new System.Windows.Forms.TextBox();
			this.gbSqlSettings = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtSqlQuery = new System.Windows.Forms.TextBox();
			this.ckbShowPwd = new System.Windows.Forms.CheckBox();
			this.btnTryConnection = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSqlTable = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSqlDB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtSqlPwd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSqlUser = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSqlInstance = new System.Windows.Forms.TextBox();
			this.tpRankings = new System.Windows.Forms.TabPage();
			this.btnRankGo = new System.Windows.Forms.Button();
			this.dgvRank = new System.Windows.Forms.DataGridView();
			this.lbRankLog = new System.Windows.Forms.ListBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.nudRankTimer = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.tmRank = new System.Windows.Forms.Timer(this.components);
			this.tabControl1.SuspendLayout();
			this.tpSettings.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.gbSqlSettings.SuspendLayout();
			this.tpRankings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvRank)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRankTimer)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Location = new System.Drawing.Point(0, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 428);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(800, 22);
			this.statusStrip1.TabIndex = 2;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpSettings);
			this.tabControl1.Controls.Add(this.tpRankings);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 49);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 379);
			this.tabControl1.TabIndex = 3;
			// 
			// tpSettings
			// 
			this.tpSettings.Controls.Add(this.groupBox1);
			this.tpSettings.Controls.Add(this.gbSqlSettings);
			this.tpSettings.Location = new System.Drawing.Point(4, 22);
			this.tpSettings.Name = "tpSettings";
			this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tpSettings.Size = new System.Drawing.Size(792, 353);
			this.tpSettings.TabIndex = 0;
			this.tpSettings.Text = "Configuração";
			this.tpSettings.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnServerPath);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.txtServerPath);
			this.groupBox1.Location = new System.Drawing.Point(246, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(538, 330);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gerais";
			// 
			// btnServerPath
			// 
			this.btnServerPath.Location = new System.Drawing.Point(214, 19);
			this.btnServerPath.Name = "btnServerPath";
			this.btnServerPath.Size = new System.Drawing.Size(23, 23);
			this.btnServerPath.TabIndex = 7;
			this.btnServerPath.Text = "...";
			this.btnServerPath.UseVisualStyleBackColor = true;
			this.btnServerPath.Click += new System.EventHandler(this.btnServerPath_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(8, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(49, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "Servidor:";
			// 
			// txtServerPath
			// 
			this.txtServerPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtServerPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtServerPath.Location = new System.Drawing.Point(80, 21);
			this.txtServerPath.Name = "txtServerPath";
			this.txtServerPath.Size = new System.Drawing.Size(128, 20);
			this.txtServerPath.TabIndex = 5;
			this.txtServerPath.Tag = "";
			this.txtServerPath.Text = "C:\\Server\\";
			// 
			// gbSqlSettings
			// 
			this.gbSqlSettings.Controls.Add(this.label6);
			this.gbSqlSettings.Controls.Add(this.txtSqlQuery);
			this.gbSqlSettings.Controls.Add(this.ckbShowPwd);
			this.gbSqlSettings.Controls.Add(this.btnTryConnection);
			this.gbSqlSettings.Controls.Add(this.label5);
			this.gbSqlSettings.Controls.Add(this.txtSqlTable);
			this.gbSqlSettings.Controls.Add(this.label4);
			this.gbSqlSettings.Controls.Add(this.txtSqlDB);
			this.gbSqlSettings.Controls.Add(this.label3);
			this.gbSqlSettings.Controls.Add(this.txtSqlPwd);
			this.gbSqlSettings.Controls.Add(this.label2);
			this.gbSqlSettings.Controls.Add(this.txtSqlUser);
			this.gbSqlSettings.Controls.Add(this.label1);
			this.gbSqlSettings.Controls.Add(this.txtSqlInstance);
			this.gbSqlSettings.Location = new System.Drawing.Point(8, 12);
			this.gbSqlSettings.Name = "gbSqlSettings";
			this.gbSqlSettings.Size = new System.Drawing.Size(232, 212);
			this.gbSqlSettings.TabIndex = 0;
			this.gbSqlSettings.TabStop = false;
			this.gbSqlSettings.Text = "Sql";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 154);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Query:";
			// 
			// txtSqlQuery
			// 
			this.txtSqlQuery.Location = new System.Drawing.Point(80, 151);
			this.txtSqlQuery.Name = "txtSqlQuery";
			this.txtSqlQuery.Size = new System.Drawing.Size(128, 20);
			this.txtSqlQuery.TabIndex = 13;
			// 
			// ckbShowPwd
			// 
			this.ckbShowPwd.AutoSize = true;
			this.ckbShowPwd.Location = new System.Drawing.Point(210, 79);
			this.ckbShowPwd.Name = "ckbShowPwd";
			this.ckbShowPwd.Size = new System.Drawing.Size(15, 14);
			this.ckbShowPwd.TabIndex = 12;
			this.ckbShowPwd.UseVisualStyleBackColor = true;
			this.ckbShowPwd.CheckedChanged += new System.EventHandler(this.ckbShowPwd_CheckedChanged);
			// 
			// btnTryConnection
			// 
			this.btnTryConnection.Location = new System.Drawing.Point(11, 177);
			this.btnTryConnection.Name = "btnTryConnection";
			this.btnTryConnection.Size = new System.Drawing.Size(197, 23);
			this.btnTryConnection.TabIndex = 11;
			this.btnTryConnection.Text = "Testar Conexão";
			this.btnTryConnection.UseVisualStyleBackColor = true;
			this.btnTryConnection.Click += new System.EventHandler(this.btnTryConnection_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Tabela:";
			// 
			// txtSqlTable
			// 
			this.txtSqlTable.Location = new System.Drawing.Point(80, 125);
			this.txtSqlTable.Name = "txtSqlTable";
			this.txtSqlTable.Size = new System.Drawing.Size(128, 20);
			this.txtSqlTable.TabIndex = 9;
			this.txtSqlTable.Text = "Level";
			this.txtSqlTable.TextChanged += new System.EventHandler(this.txtSqlTable_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Database:";
			// 
			// txtSqlDB
			// 
			this.txtSqlDB.Location = new System.Drawing.Point(80, 99);
			this.txtSqlDB.Name = "txtSqlDB";
			this.txtSqlDB.Size = new System.Drawing.Size(128, 20);
			this.txtSqlDB.TabIndex = 7;
			this.txtSqlDB.Text = "PoisonPK";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Senha:";
			// 
			// txtSqlPwd
			// 
			this.txtSqlPwd.Location = new System.Drawing.Point(80, 73);
			this.txtSqlPwd.Name = "txtSqlPwd";
			this.txtSqlPwd.Size = new System.Drawing.Size(128, 20);
			this.txtSqlPwd.TabIndex = 5;
			this.txtSqlPwd.UseSystemPasswordChar = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Usuário:";
			// 
			// txtSqlUser
			// 
			this.txtSqlUser.Location = new System.Drawing.Point(80, 47);
			this.txtSqlUser.Name = "txtSqlUser";
			this.txtSqlUser.Size = new System.Drawing.Size(128, 20);
			this.txtSqlUser.TabIndex = 3;
			this.txtSqlUser.Tag = "";
			this.txtSqlUser.Text = "sa";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Instância:";
			// 
			// txtSqlInstance
			// 
			this.txtSqlInstance.Location = new System.Drawing.Point(80, 21);
			this.txtSqlInstance.Name = "txtSqlInstance";
			this.txtSqlInstance.Size = new System.Drawing.Size(128, 20);
			this.txtSqlInstance.TabIndex = 0;
			this.txtSqlInstance.Text = "localhost";
			// 
			// tpRankings
			// 
			this.tpRankings.Controls.Add(this.btnRankGo);
			this.tpRankings.Controls.Add(this.dgvRank);
			this.tpRankings.Controls.Add(this.lbRankLog);
			this.tpRankings.Controls.Add(this.groupBox2);
			this.tpRankings.Location = new System.Drawing.Point(4, 22);
			this.tpRankings.Name = "tpRankings";
			this.tpRankings.Padding = new System.Windows.Forms.Padding(3);
			this.tpRankings.Size = new System.Drawing.Size(792, 353);
			this.tpRankings.TabIndex = 1;
			this.tpRankings.Text = "Top Level";
			this.tpRankings.UseVisualStyleBackColor = true;
			// 
			// btnRankGo
			// 
			this.btnRankGo.Location = new System.Drawing.Point(188, 31);
			this.btnRankGo.Name = "btnRankGo";
			this.btnRankGo.Size = new System.Drawing.Size(35, 23);
			this.btnRankGo.TabIndex = 8;
			this.btnRankGo.Text = "Go";
			this.btnRankGo.UseVisualStyleBackColor = true;
			this.btnRankGo.Click += new System.EventHandler(this.btnRankGo_Click);
			// 
			// dgvRank
			// 
			this.dgvRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRank.Location = new System.Drawing.Point(240, 18);
			this.dgvRank.Name = "dgvRank";
			this.dgvRank.Size = new System.Drawing.Size(544, 318);
			this.dgvRank.TabIndex = 2;
			// 
			// lbRankLog
			// 
			this.lbRankLog.FormattingEnabled = true;
			this.lbRankLog.Location = new System.Drawing.Point(8, 72);
			this.lbRankLog.Name = "lbRankLog";
			this.lbRankLog.Size = new System.Drawing.Size(224, 264);
			this.lbRankLog.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.nudRankTimer);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new System.Drawing.Point(8, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(224, 51);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Opções";
			// 
			// nudRankTimer
			// 
			this.nudRankTimer.Location = new System.Drawing.Point(80, 21);
			this.nudRankTimer.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
			this.nudRankTimer.Name = "nudRankTimer";
			this.nudRankTimer.Size = new System.Drawing.Size(90, 20);
			this.nudRankTimer.TabIndex = 7;
			this.nudRankTimer.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 6;
			this.label8.Text = "Tempo (s):";
			// 
			// tmRank
			// 
			this.tmRank.Tick += new System.EventHandler(this.tmRank_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "Tools";
			this.tabControl1.ResumeLayout(false);
			this.tpSettings.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gbSqlSettings.ResumeLayout(false);
			this.gbSqlSettings.PerformLayout();
			this.tpRankings.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvRank)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudRankTimer)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpSettings;
		private System.Windows.Forms.GroupBox gbSqlSettings;
		private System.Windows.Forms.Button btnTryConnection;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSqlTable;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSqlDB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtSqlPwd;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSqlUser;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSqlInstance;
		private System.Windows.Forms.TabPage tpRankings;
		private System.Windows.Forms.CheckBox ckbShowPwd;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtSqlQuery;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtServerPath;
		private System.Windows.Forms.Button btnServerPath;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown nudRankTimer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGridView dgvRank;
		private System.Windows.Forms.ListBox lbRankLog;
		private System.Windows.Forms.Button btnRankGo;
		private System.Windows.Forms.Timer tmRank;
	}
}

