using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace DeskTopOnline
{

    public delegate void TabAllClosedHandler(object sender);
    public delegate void FormSizeChangedHandler(FormWindowState fws);
    public partial class FormBrowserContainer : Form
    {
        public static event TabAllClosedHandler TabAllClosed = null;
        public static event FormSizeChangedHandler FormSizeChanged = null;
        public FormBrowser fbSelected = null;
        public FormBrowserContainer()
        {
            InitializeComponent();
            FormBrowser.FormBrowserClosed+=new FormBrowserClosedHandler(FormBrowser_FormBrowserClosed);
            FormBrowser.FormBrowserURLResolved+=new FormBrowserURLResolvedHandler(FormBrowser_FormBrowserURLResolved);
        }
        /// <summary>
        /// 增加新标签
        /// </summary>
        public void AddNewTab(FormBrowser fb)
        {
            //TabPage tp = new TabPage(fb.searchstr);
            TabPage tp = new TabPage();
            tp.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            tp.Width = 10;
            tp.DoubleClick+=new EventHandler(tp_DoubleClick);
            tcWebForms.TabPages.Add(tp);
            tcWebForms.TabPages[tcWebForms.TabPages.Count - 1].Controls.Add(fb);
            tcWebForms.TabPages[tcWebForms.TabPages.Count - 1].Tag = fb;
            fb.Tag = tcWebForms.TabPages[tcWebForms.TabPages.Count - 1];
            tcWebForms.SelectedTab = tcWebForms.TabPages[tcWebForms.TabPages.Count - 1];
            fbSelected = fb;
            tbWebUrl.Text = fbSelected.strUrl;
        }
        //双击关闭标签
        private void tp_DoubleClick(object sender, EventArgs e)
        { 
            
        }
        //有浏览标签请求关闭
        private void FormBrowser_FormBrowserClosed(object sender)
        {
            FormBrowser fb=sender as FormBrowser;
            int index=GetTabIndexToClosed(fb);
            if (index != -1)
            {
                this.tcWebForms.TabPages.RemoveAt(index);
                //this.tcWebForms.TabPages.Remove(fb.Parent as TabPage);
                if (this.tcWebForms.TabPages.Count == 0)
                {
                    if (TabAllClosed != null)
                    {
                        TabAllClosed(this);
                    }
                }
            }
        }
        //解析出URL地址
        private void FormBrowser_FormBrowserURLResolved(object sender)
        {
            FormBrowser fb = sender as FormBrowser;
            tbWebUrl.Text = fb.strUrl;
        }
        private int GetTabIndexToClosed(FormBrowser fb)
        {
            if (fb.Tag == null)
            {
                return -1;
            }
            return this.tcWebForms.TabPages.IndexOf((TabPage)fb.Tag);
        }
       
        private void FormBrowserContainer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb = new SolidBrush(Color.Gray);
            Pen p = new Pen(sb);
            g.DrawLine(p, 0, 0, this.Width-1, 0);
            g.DrawLine(p, 0, 0, 0, this.Height - 1);
            g.DrawLine(p,this.Width-1,0,this.Width-1,this.Height-1);
            sb.Dispose();
            p.Dispose();
            g.Dispose();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                if (FormSizeChanged != null)
                {
                    FormSizeChanged(FormWindowState.Normal);
                }
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                if (FormSizeChanged != null)
                {
                    FormSizeChanged(FormWindowState.Maximized);
                }
            }
            
            
        }

        private void btnNavigate_Click(object sender, EventArgs e)
        {
            fbSelected.WebNavigate(tbWebUrl.Text);
        }

        private void btnBackward_Click(object sender, EventArgs e)
        {
            fbSelected.WebBackWard();
        }

        private void btnForWard_Click(object sender, EventArgs e)
        {
            fbSelected.WebForWard();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fbSelected.WebRefresh();
        }

        private void btnStopNavigate_Click(object sender, EventArgs e)
        {
            fbSelected.WebStopNavigate();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            fbSelected.CloseForm();
        }

        private void tcWebForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcWebForms.TabPages.Count > 0)
            {
                fbSelected = tcWebForms.SelectedTab.Controls[0] as FormBrowser;
                tbWebUrl.Text = fbSelected.strUrl;
            }
        }

        private void tbWebUrl_DoubleClick(object sender, EventArgs e)
        {
            tbWebUrl.SelectAll();
        }
    }
}
