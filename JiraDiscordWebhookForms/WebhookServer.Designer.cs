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
			this.btn_Start.Location = new System.Drawing.Point(12, 46);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(100, 23);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "START";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// btn_Stop
			// 
			this.btn_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Stop.Location = new System.Drawing.Point(118, 46);
			this.btn_Stop.Name = "btn_Stop";
			this.btn_Stop.Size = new System.Drawing.Size(100, 23);
			this.btn_Stop.TabIndex = 1;
			this.btn_Stop.Text = "STOP";
			this.btn_Stop.UseVisualStyleBackColor = true;
			this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
			// 
			// lbl_StatusName
			// 
			this.lbl_StatusName.AutoSize = true;
			this.lbl_StatusName.Location = new System.Drawing.Point(12, 18);
			this.lbl_StatusName.Name = "lbl_StatusName";
			this.lbl_StatusName.Size = new System.Drawing.Size(74, 13);
			this.lbl_StatusName.TabIndex = 2;
			this.lbl_StatusName.Text = "Server Status:";
			// 
			// lbl_StatusValue
			// 
			this.lbl_StatusValue.Location = new System.Drawing.Point(92, 18);
			this.lbl_StatusValue.Name = "lbl_StatusValue";
			this.lbl_StatusValue.Size = new System.Drawing.Size(77, 13);
			this.lbl_StatusValue.TabIndex = 3;
			this.lbl_StatusValue.Text = "Running";
			// 
			// WebhookServer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(230, 81);
			this.Controls.Add(this.lbl_StatusValue);
			this.Controls.Add(this.lbl_StatusName);
			this.Controls.Add(this.btn_Stop);
			this.Controls.Add(this.btn_Start);
			this.MaximizeBox = false;
			this.Name = "WebhookServer";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Webhook Server";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebhookServer_FormClosing);
			this.Load += new System.EventHandler(this.WebhookServer_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Stop;
		private System.Windows.Forms.Label lbl_StatusName;
		private System.Windows.Forms.Label lbl_StatusValue;
	}
}

