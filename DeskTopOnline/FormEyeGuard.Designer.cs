namespace DeskTopOnline
{
    partial class FormEyeGuard
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudRestInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRestTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(180, 58);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(59, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "启动";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "间隔时间";
            // 
            // nudRestInterval
            // 
            this.nudRestInterval.BackColor = System.Drawing.Color.White;
            this.nudRestInterval.Location = new System.Drawing.Point(71, 4);
            this.nudRestInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRestInterval.Name = "nudRestInterval";
            this.nudRestInterval.Size = new System.Drawing.Size(89, 21);
            this.nudRestInterval.TabIndex = 2;
            this.nudRestInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRestInterval.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "分钟";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "休息时长";
            // 
            // nudRestTime
            // 
            this.nudRestTime.BackColor = System.Drawing.Color.White;
            this.nudRestTime.Location = new System.Drawing.Point(71, 33);
            this.nudRestTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRestTime.Name = "nudRestTime";
            this.nudRestTime.Size = new System.Drawing.Size(89, 21);
            this.nudRestTime.TabIndex = 2;
            this.nudRestTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRestTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "分钟";
            // 
            // FormEyeGuard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 85);
            this.Controls.Add(this.nudRestTime);
            this.Controls.Add(this.nudRestInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormEyeGuard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时休息护眼";
            this.Load += new System.EventHandler(this.EyeGuard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudRestInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRestTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudRestInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudRestTime;
        private System.Windows.Forms.Label label4;

    }
}