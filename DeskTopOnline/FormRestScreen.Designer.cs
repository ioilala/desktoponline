namespace DeskTopOnline
{
    partial class FormRestScreen
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
            this.prbTime = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // prbTime
            // 
            this.prbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.prbTime.Location = new System.Drawing.Point(104, 170);
            this.prbTime.Name = "prbTime";
            this.prbTime.Size = new System.Drawing.Size(400, 2);
            this.prbTime.TabIndex = 1;
            // 
            // FormRestScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(609, 343);
            this.Controls.Add(this.prbTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormRestScreen";
            this.ShowInTaskbar = false;
            this.Text = "FormBrowser1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormRest_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormRest_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbTime;
    }
}