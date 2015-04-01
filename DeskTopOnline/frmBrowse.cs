using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;

namespace DeskTopOnline
{
    public partial class frmBrowser : Form
    {
        public string searchstr;
        private BackgroundWorker bw = new BackgroundWorker();
        private int loadingProgress=0;
        public frmBrowser()
        {
            InitializeComponent();
            wbIE.ScriptErrorsSuppressed = true;//不显示错误对话框

            bw.RunWorkerCompleted+=new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            wbIE.ProgressChanged+=new WebBrowserProgressChangedEventHandler(wbIE_ProgressChanged);
            wbIE.PreviewKeyDown+=new PreviewKeyDownEventHandler(wbIE_PreviewKeyDown);
        }

        private void frmBrowser_Load(object sender, EventArgs e)
        {
            //wbIE.Navigate("http://www.google.com.hk/search?hl=zh-CN&q=" +);
            searchstr=searchstr.TrimStart();
            searchstr = searchstr.TrimEnd();
            //searchstr.Replace(" ", "+");
            //searchstr=HttpServerUtility.UrlTokenEncode(Encoding.ASCII.GetBytes(searchstr));
            Encoding eUtf8=Encoding.UTF8;
            searchstr=HttpUtility.UrlEncode(searchstr, eUtf8);
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            wbIE.Navigate("http://www.google.com.hk/search?newwindow=1&safe=strict&site=&source=hp&q=" + searchstr + "&btnG=Google+%E6%90%9C%E7%B4%A2");
        }

        private void frmBrowser_Shown(object sender, EventArgs e)
        {
            bw.RunWorkerAsync();
        }

        private void wbIE_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            loadingProgress = Convert.ToInt32((((float)e.CurrentProgress) / ((float)e.MaximumProgress))*100.0f);
            this.Invoke(new EventHandler(delegate
            {
                pgbLoadPage.Value = loadingProgress;
                if (pgbLoadPage.Value == pgbLoadPage.Maximum)
                {
                    pgbLoadPage.Visible = false;
                }
            }));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim(' ') == "")
            {
                return;
            }
            if (rdbGoogle.Checked)//使用google搜索引擎
            {
                wbIE.Navigate("http://www.google.com.hk/search?newwindow=1&safe=strict&site=&source=hp&q=" + searchstr + "&btnG=Google+%E6%90%9C%E7%B4%A2");
            }
        }
        private void frmBrowser_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                break;
                case Keys.Enter:
                if (btnSearch.Focused)
                {
                    btnSearch_Click(tbSearch,null);
                }
                break;
            }
        }
        private void wbIE_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F5:
                    wbIE.Refresh();
                    break;
            }
        }
    }
}
