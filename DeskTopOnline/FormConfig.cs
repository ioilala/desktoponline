using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace DeskTopOnline
{
    public delegate void GlobleKeySetHandler(object sender);
    public partial class FormConfig : Form
    {
        public static event GlobleKeySetHandler SetGlobalKey = null;
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnGlobalKeySet_Click(object sender, EventArgs e)
        {
            if (SetGlobalKey != null)
            {
                SetGlobalKey(this);
            }
        }
    }
}
