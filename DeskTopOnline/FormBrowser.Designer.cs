namespace DeskTopOnline
{
    partial class FormBrowser
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.wbIE = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbIE
            // 
            this.wbIE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbIE.Location = new System.Drawing.Point(0, 0);
            this.wbIE.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbIE.Name = "wbIE";
            this.wbIE.Size = new System.Drawing.Size(990, 402);
            this.wbIE.TabIndex = 2;
            this.wbIE.NewWindow += new System.ComponentModel.CancelEventHandler(this.wbIE_NewWindow);
            // 
            // FormBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbIE);
            this.Name = "FormBrowser";
            this.Size = new System.Drawing.Size(990, 402);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmBrowser_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser wbIE;
    }
}
