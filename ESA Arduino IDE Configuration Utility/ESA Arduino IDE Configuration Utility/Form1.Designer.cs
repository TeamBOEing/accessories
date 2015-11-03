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
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.pgbStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 96);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 3;
            // 
            // ConfigUtilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 120);
            this.Controls.Add(this.lblStatus);
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
        private System.Windows.Forms.Label lblStatus;
    }
}

