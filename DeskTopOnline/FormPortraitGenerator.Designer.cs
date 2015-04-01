namespace DeskTopOnline
{
    partial class FormPortraitGenerator
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
            this.pbImgSrc = new System.Windows.Forms.PictureBox();
            this.pb16 = new System.Windows.Forms.PictureBox();
            this.pb32 = new System.Windows.Forms.PictureBox();
            this.btnChoosePic = new System.Windows.Forms.Button();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.ofdChoosePic = new System.Windows.Forms.OpenFileDialog();
            this.lbPicPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImgSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb32)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImgSrc
            // 
            this.pbImgSrc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImgSrc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImgSrc.Location = new System.Drawing.Point(12, 47);
            this.pbImgSrc.Name = "pbImgSrc";
            this.pbImgSrc.Size = new System.Drawing.Size(285, 286);
            this.pbImgSrc.TabIndex = 0;
            this.pbImgSrc.TabStop = false;
            this.pbImgSrc.Paint += new System.Windows.Forms.PaintEventHandler(this.pbImgSrc_Paint);
            this.pbImgSrc.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImgSrc_MouseDown);
            this.pbImgSrc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImgSrc_MouseMove);
            this.pbImgSrc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImgSrc_MouseUp);
            // 
            // pb16
            // 
            this.pb16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb16.Location = new System.Drawing.Point(311, 231);
            this.pb16.Name = "pb16";
            this.pb16.Size = new System.Drawing.Size(16, 16);
            this.pb16.TabIndex = 0;
            this.pb16.TabStop = false;
            // 
            // pb32
            // 
            this.pb32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb32.Location = new System.Drawing.Point(303, 172);
            this.pb32.Name = "pb32";
            this.pb32.Size = new System.Drawing.Size(32, 32);
            this.pb32.TabIndex = 0;
            this.pb32.TabStop = false;
            // 
            // btnChoosePic
            // 
            this.btnChoosePic.Location = new System.Drawing.Point(12, 12);
            this.btnChoosePic.Name = "btnChoosePic";
            this.btnChoosePic.Size = new System.Drawing.Size(75, 23);
            this.btnChoosePic.TabIndex = 1;
            this.btnChoosePic.Text = "选择图片";
            this.btnChoosePic.UseVisualStyleBackColor = true;
            this.btnChoosePic.Click += new System.EventHandler(this.btnChoosePic_Click);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Location = new System.Drawing.Point(265, 343);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerate.TabIndex = 1;
            this.BtnGenerate.Text = "生成图标";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // ofdChoosePic
            // 
            this.ofdChoosePic.FileName = "选择头像";
            this.ofdChoosePic.Filter = "Jpg图片(.jpg)|*.jpg|Png图片(.png)|*.png|Bmp图片(.bmp)|*.bmp";
            // 
            // lbPicPath
            // 
            this.lbPicPath.AutoSize = true;
            this.lbPicPath.Location = new System.Drawing.Point(94, 18);
            this.lbPicPath.Name = "lbPicPath";
            this.lbPicPath.Size = new System.Drawing.Size(0, 12);
            this.lbPicPath.TabIndex = 2;
            // 
            // FormPortraitGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 378);
            this.Controls.Add(this.lbPicPath);
            this.Controls.Add(this.BtnGenerate);
            this.Controls.Add(this.btnChoosePic);
            this.Controls.Add(this.pb32);
            this.Controls.Add(this.pb16);
            this.Controls.Add(this.pbImgSrc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPortraitGenerator";
            this.ShowInTaskbar = false;
            this.Text = "头像生成器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPortraitGenerator_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbImgSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb32)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImgSrc;
        private System.Windows.Forms.PictureBox pb16;
        private System.Windows.Forms.PictureBox pb32;
        private System.Windows.Forms.Button btnChoosePic;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.OpenFileDialog ofdChoosePic;
        private System.Windows.Forms.Label lbPicPath;
    }
}