namespace DeskTopOnline
{
    partial class FormConfig
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowsePicture = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGlobalKeySet = new System.Windows.Forms.Button();
            this.btnStartShow = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStopShow = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowsePicture);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 162);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "界面设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "按钮图标";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "显停位置";
            // 
            // btnBrowsePicture
            // 
            this.btnBrowsePicture.Font = new System.Drawing.Font("Verdana", 8F);
            this.btnBrowsePicture.Location = new System.Drawing.Point(92, 50);
            this.btnBrowsePicture.Name = "btnBrowsePicture";
            this.btnBrowsePicture.Size = new System.Drawing.Size(66, 23);
            this.btnBrowsePicture.TabIndex = 0;
            this.btnBrowsePicture.Text = "选择图片";
            this.btnBrowsePicture.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Verdana", 8F);
            this.button2.Location = new System.Drawing.Point(92, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "开始设置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 8F);
            this.button1.Location = new System.Drawing.Point(175, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "系统默认";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGlobalKeySet);
            this.groupBox2.Location = new System.Drawing.Point(336, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 162);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "快捷键";
            // 
            // btnGlobalKeySet
            // 
            this.btnGlobalKeySet.Location = new System.Drawing.Point(24, 26);
            this.btnGlobalKeySet.Name = "btnGlobalKeySet";
            this.btnGlobalKeySet.Size = new System.Drawing.Size(92, 23);
            this.btnGlobalKeySet.TabIndex = 0;
            this.btnGlobalKeySet.Text = "全局键[Win+S]";
            this.btnGlobalKeySet.UseVisualStyleBackColor = true;
            this.btnGlobalKeySet.Click += new System.EventHandler(this.btnGlobalKeySet_Click);
            // 
            // btnStartShow
            // 
            this.btnStartShow.Location = new System.Drawing.Point(21, 33);
            this.btnStartShow.Name = "btnStartShow";
            this.btnStartShow.Size = new System.Drawing.Size(75, 23);
            this.btnStartShow.TabIndex = 2;
            this.btnStartShow.Text = "开始特效";
            this.btnStartShow.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStopShow);
            this.groupBox3.Controls.Add(this.btnStartShow);
            this.groupBox3.Location = new System.Drawing.Point(12, 180);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 180);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "情侣功能";
            // 
            // btnStopShow
            // 
            this.btnStopShow.Location = new System.Drawing.Point(102, 33);
            this.btnStopShow.Name = "btnStopShow";
            this.btnStopShow.Size = new System.Drawing.Size(75, 23);
            this.btnStopShow.TabIndex = 2;
            this.btnStopShow.Text = "停止特效";
            this.btnStopShow.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 367);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConfig";
            this.ShowInTaskbar = false;
            this.Text = "系统设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGlobalKeySet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowsePicture;
        private System.Windows.Forms.Button btnStartShow;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStopShow;
    }
}