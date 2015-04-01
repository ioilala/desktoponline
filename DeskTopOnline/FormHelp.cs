using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace DeskTopOnline
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }
        
        private void FormHelp_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
        
        private void linkLabelHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://user.qzone.qq.com/786869722/main");
            Process.Start(@"http://www.renren.com/232653027");
        }
        
        private void FormHelp_Load(object sender, EventArgs e)
        {

        }
    }
}
