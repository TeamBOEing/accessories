namespace ESA_Arduino_IDE_Configuration_Utility
{
    partial class ConfigUtilityForm
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblDownload1 = new System.Windows.Forms.Label();
            this.lblDownload2 = new System.Windows.Forms.Label();
            this.lblInstall1 = new System.Windows.Forms.Label();
            this.lblUpdateIDE = new System.Windows.Forms.Label();
            this.lblInstall2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.MaximumSize = new System.Drawing.Size(365, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDescription.Size = new System.Drawing.Size(364, 39);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "This software installs the BOEbot support libraries, the robot project template f" +
    "ile, the robot test suite, and performs other configuration operations on the ID" +
    "E.";
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(15, 63);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(361, 23);
            this.pgbStatus.Step = 20;
            this.pgbStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbStatus.TabIndex = 1;
            // 
            // lblDownload1
            // 
            this.lblDownload1.AutoSize = true;
            this.lblDownload1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDownload1.Location = new System.Drawing.Point(12, 100);
            this.lblDownload1.Name = "lblDownload1";
            this.lblDownload1.Size = new System.Drawing.Size(156, 13);
            this.lblDownload1.TabIndex = 2;
            this.lblDownload1.Text = "Downloading BOEbot libraries...";
            // 
            // lblDownload2
            // 
            this.lblDownload2.AutoSize = true;
            this.lblDownload2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDownload2.Location = new System.Drawing.Point(12, 120);
            this.lblDownload2.Name = "lblDownload2";
            this.lblDownload2.Size = new System.Drawing.Size(274, 13);
            this.lblDownload2.TabIndex = 3;
            this.lblDownload2.Text = "Downloading BOEbot Project Template and Test Code...";
            // 
            // lblInstall1
            // 
            this.lblInstall1.AutoSize = true;
            this.lblInstall1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInstall1.Location = new System.Drawing.Point(12, 160);
            this.lblInstall1.Name = "lblInstall1";
            this.lblInstall1.Size = new System.Drawing.Size(135, 13);
            this.lblInstall1.TabIndex = 5;
            this.lblInstall1.Text = "Installing BOEbot libraries...";
            // 
            // lblUpdateIDE
            // 
            this.lblUpdateIDE.AutoSize = true;
            this.lblUpdateIDE.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUpdateIDE.Location = new System.Drawing.Point(12, 140);
            this.lblUpdateIDE.Name = "lblUpdateIDE";
            this.lblUpdateIDE.Size = new System.Drawing.Size(184, 13);
            this.lblUpdateIDE.TabIndex = 4;
            this.lblUpdateIDE.Text = "Updating Arduino IDE Configuration...";
            // 
            // lblInstall2
            // 
            this.lblInstall2.AutoSize = true;
            this.lblInstall2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInstall2.Location = new System.Drawing.Point(12, 180);
            this.lblInstall2.Name = "lblInstall2";
            this.lblInstall2.Size = new System.Drawing.Size(253, 13);
            this.lblInstall2.TabIndex = 6;
            this.lblInstall2.Text = "Installing BOEbot Project Template and Test Code...";
            // 
            // ConfigUtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 207);
            this.Controls.Add(this.lblInstall2);
            this.Controls.Add(this.lblInstall1);
            this.Controls.Add(this.lblUpdateIDE);
            this.Controls.Add(this.lblDownload2);
            this.Controls.Add(this.lblDownload1);
            this.Controls.Add(this.pgbStatus);
            this.Controls.Add(this.lblDescription);
            this.Name = "ConfigUtilityForm";
            this.Text = "ESA Arduino IDE Configuration Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblDownload1;
        private System.Windows.Forms.Label lblDownload2;
        private System.Windows.Forms.Label lblInstall1;
        private System.Windows.Forms.Label lblUpdateIDE;
        private System.Windows.Forms.Label lblInstall2;
    }
}

