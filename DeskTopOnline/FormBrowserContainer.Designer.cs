namespace DeskTopOnline
{
    partial class FormBrowserContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBrowserContainer));
            this.tcWebForms = new System.Windows.Forms.TabControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnStopNavigate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnForWard = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnNavigate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbWebUrl = new System.Windows.Forms.TextBox();
            this.btnMaximize = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcWebForms
            // 
            this.tcWebForms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcWebForms.Location = new System.Drawing.Point(0, -1);
            this.tcWebForms.Name = "tcWebForms";
            this.tcWebForms.SelectedIndex = 0;
            this.tcWebForms.Size = new System.Drawing.Size(994, 379);
            this.tcWebForms.TabIndex = 0;
            this.tcWebForms.SelectedIndexChanged += new System.EventHandler(this.tcWebForms_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnMaximize);
            this.panel1.Controls.Add(this.btnCloseForm);
            this.panel1.Controls.Add(this.btnStopNavigate);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnForWard);
            this.panel1.Controls.Add(this.btnBackward);
            this.panel1.Controls.Add(this.btnNavigate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 35);
            this.panel1.TabIndex = 4;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCloseForm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCloseForm.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCloseForm.Image = global::DeskTopOnline.Properties.Resources.Close_32;
            this.btnCloseForm.Location = new System.Drawing.Point(871, 4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(59, 27);
            this.btnCloseForm.TabIndex = 1;
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnStopNavigate
            // 
            this.btnStopNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopNavigate.Image = global::DeskTopOnline.Properties.Resources.Stop_16;
            this.btnStopNavigate.Location = new System.Drawing.Point(813, 4);
            this.btnStopNavigate.Name = "btnStopNavigate";
            this.btnStopNavigate.Size = new System.Drawing.Size(59, 27);
            this.btnStopNavigate.TabIndex = 1;
            this.btnStopNavigate.UseVisualStyleBackColor = true;
            this.btnStopNavigate.Click += new System.EventHandler(this.btnStopNavigate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::DeskTopOnline.Properties.Resources.Refresh_Blue_16;
            this.btnRefresh.Location = new System.Drawing.Point(755, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(59, 27);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnForWard
            // 
            this.btnForWard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnForWard.Image = global::DeskTopOnline.Properties.Resources.Arraw_Right_16;
            this.btnForWard.Location = new System.Drawing.Point(697, 4);
            this.btnForWard.Name = "btnForWard";
            this.btnForWard.Size = new System.Drawing.Size(59, 27);
            this.btnForWard.TabIndex = 1;
            this.btnForWard.UseVisualStyleBackColor = true;
            this.btnForWard.Click += new System.EventHandler(this.btnForWard_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackward.Image = global::DeskTopOnline.Properties.Resources.Arraw_Left_16;
            this.btnBackward.Location = new System.Drawing.Point(639, 4);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(59, 27);
            this.btnBackward.TabIndex = 1;
            this.btnBackward.UseVisualStyleBackColor = true;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnNavigate
            // 
            this.btnNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavigate.Image = global::DeskTopOnline.Properties.Resources.Internet_Go_16;
            this.btnNavigate.Location = new System.Drawing.Point(581, 4);
            this.btnNavigate.Name = "btnNavigate";
            this.btnNavigate.Size = new System.Drawing.Size(59, 27);
            this.btnNavigate.TabIndex = 1;
            this.btnNavigate.UseVisualStyleBackColor = true;
            this.btnNavigate.Click += new System.EventHandler(this.btnNavigate_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tbWebUrl);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(581, 29);
            this.panel2.TabIndex = 0;
            // 
            // tbWebUrl
            // 
            this.tbWebUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWebUrl.BackColor = System.Drawing.Color.White;
            this.tbWebUrl.Font = new System.Drawing.Font("Verdana", 10F);
            this.tbWebUrl.Location = new System.Drawing.Point(2, 4);
            this.tbWebUrl.Name = "tbWebUrl";
            this.tbWebUrl.Size = new System.Drawing.Size(576, 24);
            this.tbWebUrl.TabIndex = 9;
            this.tbWebUrl.DoubleClick += new System.EventHandler(this.tbWebUrl_DoubleClick);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnMaximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMaximize.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnMaximize.Location = new System.Drawing.Point(929, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(59, 27);
            this.btnMaximize.TabIndex = 1;
            this.btnMaximize.UseVisualStyleBackColor = true;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // FormBrowserContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tcWebForms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormBrowserContainer";
            this.ShowInTaskbar = false;
            this.Text = "桌面在线";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormBrowserContainer_Paint);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnStopNavigate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnForWard;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnNavigate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbWebUrl;
        private System.Windows.Forms.TabControl tcWebForms;
        private System.Windows.Forms.Button btnMaximize;




    }
}