using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DeskTopOnline
{
    public delegate void FormBrowserClosedHandler(object sender);
    public delegate void FormBrowserURLResolvedHandler(object sender);
    public delegate void FormBrowserNewWindowHandler(string url);
    /// <summary>
    /// 搜索引擎枚举
    /// </summary>
    public enum EnumSearchEngine
    {
        HEAD_NULL,
        GOOGLE_WEB,//谷歌网页搜索
        BAIDU_WEB,//百度网页搜索
        BAIDU_ZHIDAO,
        BAIDU_BAIKE,
        BAIDU_MUSIC,
        BAIDU_MAP,
        BAIDU_WENKU,
        BAIDU_APP,
        ICON_EASY,
        GOOGLE_FANYI,//有道翻译
        LOCAL_FILE,//本地文件搜索
        LOCAL_PICTURE,//本地图片搜索
        LOCAL_VIDEO,//本地视频搜索
        LOCAL_APP,//本地应用搜索
        OPEN_URL,//打开网站
        END_NULL,
    }
    public partial class FormBrowser : UserControl
    {
        #region 类定义区
        public static event FormBrowserClosedHandler FormBrowserClosed;
        public static event FormBrowserURLResolvedHandler FormBrowserURLResolved;
        public static event FormBrowserNewWindowHandler FormBrowserNewWindow;
        public string searchstr;//检索字符串（URL网址）
        public int formIndex;//窗体的唯一索引编号
        private BackgroundWorker bw = new BackgroundWorker();
        private int loadingProgress = 0;
        private EnumSearchEngine enumSE = new EnumSearchEngine();
        public string strUrl = null;//url地址字符串
        #endregion
        #region 启动相关
        public FormBrowser(string str,EnumSearchEngine en)
        {
            searchstr = str;
            enumSE = en;
            InitializeComponent();
            wbIE.ScriptErrorsSuppressed = false;//不显示错误对话框
            wbIE.AllowWebBrowserDrop = false;
            wbIE.WebBrowserShortcutsEnabled = true;
            wbIE.IsWebBrowserContextMenuEnabled = true;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            //wbIE.ProgressChanged += new WebBrowserProgressChangedEventHandler(wbIE_ProgressChanged);
            wbIE.PreviewKeyDown += new PreviewKeyDownEventHandler(wbIE_PreviewKeyDown);
            wbIE.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbIE_DocumentCompleted);
            bw.RunWorkerAsync();
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (enumSE)
            {
                case EnumSearchEngine.GOOGLE_WEB://google搜索使用utf8编码
                    searchstr = FuncLib.StrToUtf8(searchstr);
                    strUrl = @"http://www.google.com.hk/search?newwindow=1&safe=strict&site=&source=hp&q=" + searchstr + "&btnG=Google+%E6%90%9C%E7%B4%A2";
                    break;
                case EnumSearchEngine.BAIDU_WEB:
                    searchstr = FuncLib.StrToUtf8(searchstr);
                    strUrl = "http://www.baidu.com/baidu?word=" + searchstr + "&ie=utf-8";
                    break;
                case EnumSearchEngine.BAIDU_ZHIDAO:
                    searchstr = FuncLib.StrToUtf8(searchstr);
                    strUrl = @"http://zhidao.baidu.com/search?lm=0&rn=10&pn=0&fr=search&ie=utf-8&word=" + searchstr;
                    break;
                case EnumSearchEngine.BAIDU_WENKU:
                    searchstr = FuncLib.StrToUtf8(searchstr);
                    strUrl = @"http://wenku.baidu.com/search?word=" + searchstr + "&ie=utf-8&lm=0&od=0&fr=top_home";
                    break;
                case EnumSearchEngine.BAIDU_MUSIC:
                    searchstr = FuncLib.StrToUtf8(searchstr);
                    strUrl = @"http://music.baidu.com/search?key=" + searchstr + "&ie=utf-8";
                    break;
                case EnumSearchEngine.BAIDU_MAP:
                    strUrl = @"http://api.map.baidu.com/geocoder?address=" + searchstr + "&output=html";
                    break;
                case EnumSearchEngine.BAIDU_BAIKE:
                    searchstr = FuncLib.StrToGb2312(searchstr);
                    strUrl = @"http://baike.baidu.com/search?word=" + searchstr + "&type=0&pn=0&rn=10&submit=search";
                    break;
                case EnumSearchEngine.ICON_EASY:
                    strUrl = @"http://www.easyicon.net/iconsearch/" + searchstr;
                    break;
                case EnumSearchEngine.BAIDU_APP:
                    searchstr = FuncLib.StrToGb2312(searchstr);
                    strUrl = @"http://m.baidu.com/s?st=10a001&tn=webmkt&pre=web_am_index&word=" + searchstr;
                    break;
                case EnumSearchEngine.OPEN_URL:
                    strUrl = searchstr;
                    break;
                case EnumSearchEngine.GOOGLE_FANYI:
                    searchstr = FuncLib.StrToGb2312(searchstr);
                    strUrl = @"http://translate.google.cn/?hl=zh-CN&tab=wT#auto/zh-CN/" + searchstr;
                    break;
                case EnumSearchEngine.LOCAL_FILE:
                    break;
                case EnumSearchEngine.LOCAL_PICTURE:
                    break;
                case EnumSearchEngine.LOCAL_VIDEO:
                    break;
                case EnumSearchEngine.LOCAL_APP:
                    break;
            }
            this.Invoke(new EventHandler(delegate
            {
            if (FormBrowserURLResolved != null)
            {
                FormBrowserURLResolved(this);
            }
            wbIE.Navigate(strUrl);
            //激活主窗体
            wbIE.Focus();
            }));
        }
        #endregion 
        #region 事件集合
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (FormBrowserClosed != null)
            {
                FormBrowserClosed(this);
            }
            base.Dispose(disposing);
        }
        //将所有链接改为在本窗口打开
        private void wbIE_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbIE.Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
            foreach (HtmlElement archor in wbIE.Document.Links)
            {
            //    //archor.SetAttribute("target", "_self");
                archor.SetAttribute("target", "_blank");
            }
        }

        //private void wbIE_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        //{
        //    loadingProgress = Convert.ToInt32((((float)e.CurrentProgress) / ((float)e.MaximumProgress)) * 100.0f);
        //    this.Invoke(new EventHandler(delegate
        //    {
        //        if (loadingProgress > 0 && loadingProgress <= 100)
        //        {
        //            pgbLoadPage.Value = loadingProgress;
        //            if (pgbLoadPage.Value == pgbLoadPage.Maximum)
        //            {
        //                pgbLoadPage.Visible = false;
        //            }
        //        }
        //    }));
        //}

        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            //...自己处理
            e.Handled = true;
        }

        private void frmBrowser_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        //if (FormBrowserClosed != null)
                        //{
                        //    FormBrowserClosed(this);
                        //}
                        //this.Close();
                        break;
                    case Keys.Enter:

                        break;
                }
            }
            if (e.Control && !e.Shift && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        if (FormBrowserClosed != null)
                        {
                            FormBrowserClosed(this);
                        }
                        break;
                }
            }
        }

        private void wbIE_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //if (FormBrowserClosed != null)
                    //{
                    //    FormBrowserClosed(this);
                    //}
                    break;
                case Keys.F5:
                    wbIE.Refresh();
                    break;
            }

            if (e.Control && !e.Shift && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        this.Dispose(true);
                        break;
                    case Keys.Right:
                        wbIE.GoForward();
                        break;
                    case Keys.Left:
                        wbIE.GoBack();
                        break;
                    case Keys.F5://停止
                        wbIE.Stop();
                        break;
                    case Keys.P:
                        wbIE.ShowPrintDialog();
                        break;
                }
            }
        }

        private void tbWebUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Control | e.Alt | e.Shift) == false)
            {
                switch(e.KeyCode)
                {
                    case Keys.Enter:
                        WebNavigate(searchstr);
                        break;
                }
            }
        }

        private void FormBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            wbIE.Dispose();
            wbIE = null;
            if (FormBrowserClosed != null)
            {
                FormBrowserClosed(this);
            }
        }
        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="url"></param>
        public void WebNavigate(string url)
        {
            strUrl = url;
            strUrl.Trim(' ');
            strUrl = strUrl.ToLowerInvariant();
            if (!strUrl.StartsWith("http://"))
            {
                strUrl = @"http://" + strUrl;
            }

            if (FuncLib.IsURL(strUrl))
            {
                wbIE.Navigate(strUrl);
            }
        }
        /// <summary>
        /// 向后导航
        /// </summary>
        public void WebBackWard()
        {
            wbIE.GoBack();
        }
        /// <summary>
        /// 向前导航
        /// </summary>
        public void WebForWard()
        {
            wbIE.GoForward();
        }

        public void WebRefresh()
        {
            wbIE.Refresh();
        }

        public void WebStopNavigate()
        {
            wbIE.Stop();
        }

        public void CloseForm()
        {
            if (FormBrowserClosed != null)
            {
                FormBrowserClosed(this);
            }
        }

        private void wbIE_NewWindow(object sender, CancelEventArgs e)
        {
            string url = wbIE.Document.ActiveElement.GetAttribute("href");
            if (url == "")
            {
                return;
            }
            if (FormBrowserNewWindow != null)
            {
                FormBrowserNewWindow(url);
            }
            e.Cancel = true;
        }
        #endregion
    }
}
