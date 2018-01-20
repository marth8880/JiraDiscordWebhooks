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
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Stop = new System.Windows.Forms.Button();
			this.lbl_StatusName = new System.Windows.Forms.Label();
			this.lbl_StatusValue = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txt_BotName = new System.Windows.Forms.TextBox();
			this.txt_DiscordURL = new System.Windows.Forms.TextBox();
			this.txt_JiraBaseURL = new System.Windows.Forms.TextBox();
			this.txt_JiraIconURL = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_LocalIP = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_SaveSettings = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.Text = "JIRA Discord Webhook Server";
			this.notifyIcon.Visible = true;
			// 
			// btn_Start
			// 
			this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_Start.Location = new System.Drawing.Point(12, 171);
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
			this.btn_Stop.Location = new System.Drawing.Point(118, 171);
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
			this.tableLayoutPanel1.Controls.Add(this.txt_BotName, 1, 5);
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
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 150);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// txt_BotName
			// 
			this.txt_BotName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txt_BotName.Location = new System.Drawing.Point(133, 128);
			this.txt_BotName.Name = "txt_BotName";
			this.txt_BotName.Size = new System.Drawing.Size(298, 20);
			this.txt_BotName.TabIndex = 12;
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
			// btn_SaveSettings
			// 
			this.btn_SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_SaveSettings.Location = new System.Drawing.Point(346, 171);
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
			this.ClientSize = new System.Drawing.Size(461, 206);
			this.Controls.Add(this.btn_SaveSettings);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.btn_Stop);
			this.Controls.Add(this.btn_Start);
			this.MaximizeBox = false;
			this.Name = "WebhookServer";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Webhook Server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebhookServer_FormClosing);
			this.Load += new System.EventHandler(this.WebhookServer_Load);
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
	}
}

