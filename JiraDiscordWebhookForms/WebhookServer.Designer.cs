namespace JiraDiscordWebhookForms
{
	partial class WebhookServer
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
			if (disposing && (components != null))
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebhookServer));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Stop = new System.Windows.Forms.Button();
			this.lbl_StatusName = new System.Windows.Forms.Label();
			this.lbl_StatusValue = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_DiscordURL = new System.Windows.Forms.TextBox();
			this.txt_JiraBaseURL = new System.Windows.Forms.TextBox();
			this.txt_JiraIconURL = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_LocalIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_TaskIconURL = new System.Windows.Forms.TextBox();
			this.txt_EpicIconURL = new System.Windows.Forms.TextBox();
			this.txt_BotName = new System.Windows.Forms.TextBox();
			this.txt_BugIconURL = new System.Windows.Forms.TextBox();
			this.btn_SaveSettings = new System.Windows.Forms.Button();
			this.trayContextMenuStrip.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.trayContextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "JIRA Webhook Server: Idle";
			this.notifyIcon.Visible = true;
			this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
			// 
			// trayContextMenuStrip
			// 
			this.trayContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.toolStripSeparator2,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
			this.trayContextMenuStrip.Name = "trayContextMenuStrip";
			this.trayContextMenuStrip.Size = new System.Drawing.Size(140, 104);
			// 
			// showHideToolStripMenuItem
			// 
			this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
			this.showHideToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.showHideToolStripMenuItem.Text = "Show / Hide";
			this.showHideToolStripMenuItem.Click += new System.EventHandler(this.toggleVisibilityToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
			// 
			// startToolStripMenuItem
			// 
			this.startToolStripMenuItem.Name = "startToolStripMenuItem";
			this.startToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.startToolStripMenuItem.Text = "Start";
			this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// btn_Start
			// 
			this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Start.Location = new System.Drawing.Point(12, 274);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(100, 23);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "Start";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// btn_Stop
			// 
			this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Stop.Location = new System.Drawing.Point(118, 274);
			this.btn_Stop.Name = "btn_Stop";
			this.btn_Stop.Size = new System.Drawing.Size(100, 23);
			this.btn_Stop.TabIndex = 1;
			this.btn_Stop.Text = "Stop";
			this.btn_Stop.UseVisualStyleBackColor = true;
			this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
			// 
			// lbl_StatusName
			// 
			this.lbl_StatusName.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbl_StatusName.AutoSize = true;
			this.lbl_StatusName.Location = new System.Drawing.Point(53, 6);
			this.lbl_StatusName.Name = "lbl_StatusName";
			this.lbl_StatusName.Size = new System.Drawing.Size(74, 13);
			this.lbl_StatusName.TabIndex = 2;
			this.lbl_StatusName.Text = "Server Status:";
			// 
			// lbl_StatusValue
			// 
			this.lbl_StatusValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbl_StatusValue.Location = new System.Drawing.Point(133, 6);
			this.lbl_StatusValue.Name = "lbl_StatusValue";
			this.lbl_StatusValue.Size = new System.Drawing.Size(77, 13);
			this.lbl_StatusValue.TabIndex = 3;
			this.lbl_StatusValue.Text = "Running";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
			this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.lbl_StatusValue, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.txt_DiscordURL, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.lbl_StatusName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.txt_JiraBaseURL, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.txt_JiraIconURL, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.label8, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.txt_LocalIP, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.txt_TaskIconURL, 1, 7);
			this.tableLayoutPanel1.Controls.Add(this.txt_EpicIconURL, 1, 8);
			this.tableLayoutPanel1.Controls.Add(this.txt_BotName, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.txt_BugIconURL, 1, 6);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 9;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 225);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(47, 206);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(80, 13);
			this.label11.TabIndex = 18;
			this.label11.Text = "Epic Icon URL:";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(44, 181);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(83, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "Task Icon URL:";
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(49, 156);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(78, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "Bug Icon URL:";
			// 
			// txt_DiscordURL
			// 
			this.txt_DiscordURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_DiscordURL.Location = new System.Drawing.Point(133, 103);
			this.txt_DiscordURL.Name = "txt_DiscordURL";
			this.txt_DiscordURL.Size = new System.Drawing.Size(298, 20);
			this.txt_DiscordURL.TabIndex = 11;
			// 
			// txt_JiraBaseURL
			// 
			this.txt_JiraBaseURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_JiraBaseURL.Location = new System.Drawing.Point(133, 78);
			this.txt_JiraBaseURL.Name = "txt_JiraBaseURL";
			this.txt_JiraBaseURL.Size = new System.Drawing.Size(298, 20);
			this.txt_JiraBaseURL.TabIndex = 10;
			// 
			// txt_JiraIconURL
			// 
			this.txt_JiraIconURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_JiraIconURL.Location = new System.Drawing.Point(133, 53);
			this.txt_JiraIconURL.Name = "txt_JiraIconURL";
			this.txt_JiraIconURL.Size = new System.Drawing.Size(298, 20);
			this.txt_JiraIconURL.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(70, 131);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 8;
			this.label8.Text = "Bot Name:";
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 106);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(121, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Discord Webhook URL:";
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(49, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Jira Base URL:";
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(52, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Jira Icon URL:";
			// 
			// txt_LocalIP
			// 
			this.txt_LocalIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_LocalIP.Location = new System.Drawing.Point(133, 28);
			this.txt_LocalIP.Name = "txt_LocalIP";
			this.txt_LocalIP.Size = new System.Drawing.Size(298, 20);
			this.txt_LocalIP.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(78, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Local IP:";
			// 
			// txt_TaskIconURL
			// 
			this.txt_TaskIconURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_TaskIconURL.Location = new System.Drawing.Point(133, 178);
			this.txt_TaskIconURL.Name = "txt_TaskIconURL";
			this.txt_TaskIconURL.Size = new System.Drawing.Size(298, 20);
			this.txt_TaskIconURL.TabIndex = 20;
			// 
			// txt_EpicIconURL
			// 
			this.txt_EpicIconURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_EpicIconURL.Location = new System.Drawing.Point(133, 203);
			this.txt_EpicIconURL.Name = "txt_EpicIconURL";
			this.txt_EpicIconURL.Size = new System.Drawing.Size(298, 20);
			this.txt_EpicIconURL.TabIndex = 21;
			// 
			// txt_BotName
			// 
			this.txt_BotName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_BotName.Location = new System.Drawing.Point(133, 128);
			this.txt_BotName.Name = "txt_BotName";
			this.txt_BotName.Size = new System.Drawing.Size(298, 20);
			this.txt_BotName.TabIndex = 12;
			// 
			// txt_BugIconURL
			// 
			this.txt_BugIconURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_BugIconURL.Location = new System.Drawing.Point(133, 153);
			this.txt_BugIconURL.Name = "txt_BugIconURL";
			this.txt_BugIconURL.Size = new System.Drawing.Size(298, 20);
			this.txt_BugIconURL.TabIndex = 19;
			// 
			// btn_SaveSettings
			// 
			this.btn_SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_SaveSettings.Location = new System.Drawing.Point(346, 274);
			this.btn_SaveSettings.Name = "btn_SaveSettings";
			this.btn_SaveSettings.Size = new System.Drawing.Size(100, 23);
			this.btn_SaveSettings.TabIndex = 5;
			this.btn_SaveSettings.Text = "Save Settings";
			this.btn_SaveSettings.UseVisualStyleBackColor = true;
			this.btn_SaveSettings.Click += new System.EventHandler(this.btn_SaveSettings_Click);
			// 
			// WebhookServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(461, 309);
			this.Controls.Add(this.btn_SaveSettings);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.btn_Stop);
			this.Controls.Add(this.btn_Start);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "WebhookServer";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "JIRA Webhook Server";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebhookServer_FormClosing);
			this.Load += new System.EventHandler(this.WebhookServer_Load);
			this.Resize += new System.EventHandler(this.WebhookServer_Resize);
			this.trayContextMenuStrip.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Stop;
		private System.Windows.Forms.Label lbl_StatusName;
		private System.Windows.Forms.Label lbl_StatusValue;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_LocalIP;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_BotName;
		private System.Windows.Forms.TextBox txt_DiscordURL;
		private System.Windows.Forms.TextBox txt_JiraBaseURL;
		private System.Windows.Forms.TextBox txt_JiraIconURL;
		private System.Windows.Forms.Button btn_SaveSettings;
		private System.Windows.Forms.ContextMenuStrip trayContextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txt_TaskIconURL;
		private System.Windows.Forms.TextBox txt_EpicIconURL;
		private System.Windows.Forms.TextBox txt_BugIconURL;
	}
}

