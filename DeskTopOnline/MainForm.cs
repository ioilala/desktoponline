using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using CSharpWin_JD.CaptureImage;

namespace DeskTopOnline
{
    /*********************************
     * 版本:1.1.6.2
     * 问题:
     * .listBrowser.RemoveAt bug，索引超出范围
     * .保护眼睛休息存在bug
     * .显示/隐藏界面存在bug
     * 修改：
     * .增加截图功能ok
     * .加入系统控制功能(关机、重启、休眠、注销)
     * .整合右键菜单，加入功能组件、软件设置、系统控制
     * .修改浏览器自定义控件，将控制按钮移到外面的容器中去
     * .增加浏览器控件NewWindow事件，截获浏览器打开新窗口事件
     * .删除加载进度条
     * ********************************/
    public partial class MainForm : Form
    {
        #region 系统定义
        //private Socket udpCommClient;//命令字socket client
        //private Socket udpMsgClient;//文本消息socket client
        //private Socket udpFileClient;//文件传输socket client
        private Socket udpCommServer;//命令字socket server
        private Socket udpMsgServer;//文本消息socket server
        private Socket udpFileServer;//文件传输 socket server

        public List<FormBrowser> listFormBrowser = new List<FormBrowser>();
        private FormBrowser fb = new FormBrowser("",EnumSearchEngine.END_NULL);//浏览器控件
        private FormHelp fh = null;//帮助窗口
        private FormBrowserContainer fbc = new FormBrowserContainer();//浏览器窗口容器
        private FormEyeGuard feyeGuard = new FormEyeGuard();//护眼模式设置

        private Point WebFormStartPosition = new Point();
        private Point MainFormStartPosition = new Point();

        private string exeName = null;//程序的进程名
        private bool flagFormDocked = false;//是否靠边
        private bool flagFormShow = true;//是否显示
        private bool flagFormExpand = false;//是否展开搜索引擎选择
        private bool flagGlobalHotKeySet = false;//全局快捷键是否注册成功
        private bool flagEyeGuardOpen = false;//护眼模式开启标志
        

        private const int WIN_S = 100;//
        private const int CTL_ALT_A = 101;//截屏
        private const int CTL_ALT_SHIFT_X = 102;//关机
        private const int CTL_ALT_SHIFT_S = 103;//休眠
        private const int CTL_ALT_SHIFT_R = 104;//重启
        private const int WIN_F12 = 105;//老板键
        private const int MAIN_FORM_DOCK_X = -545;
        private const int PORT_COMM = 3520;
        private const int PORT_MSG = PORT_COMM + 1;
        private const int PORT_FILE = PORT_COMM + 2;
        private const string DISPLAY_NAME = "桌面在线";

        private Size FB_Normal_Size = new Size(1000, 434);
        private EnumSearchEngine enumCurrentSE = new EnumSearchEngine();//当前的搜索引擎，自动记忆上次使用的习惯，改变搜索按钮的行为
        //private FileStream fswUserInput=null;//用户输入文件流，写模式
        //private FileStream fsrUserInput = null;//用户输入文件流，读模式
        //private StreamWriter swUserInput = null;//用户输入写文件
        //private StreamReader srUserInput = null;//用户输入读文件
        private BackgroundWorker bwInit = new BackgroundWorker();
        #endregion
        #region 软件启动
        //构造函数
        public MainForm()
        {
            FuncLib.CheckSingleThread();
            InitializeComponent();

            exeName = Process.GetCurrentProcess().ProcessName;

            Rectangle rt = Screen.PrimaryScreen.WorkingArea;
            int formwidth = this.Width;
            int formheight = this.Height;
            int startx = Convert.ToInt32(((float)rt.Width - (float)this.Width) / 2.0f);
            int starty = Convert.ToInt32((float)rt.Height * 2.0f / 3.0);
            MainFormStartPosition = new Point(startx, starty);
            frmToDock();
            enumCurrentSE = EnumSearchEngine.GOOGLE_WEB;
            //注册委托事件
            FormBrowser.FormBrowserClosed += new FormBrowserClosedHandler(FormBrowser_HandleBackFormBrowserClosed);
            FormBrowser.FormBrowserNewWindow+=new FormBrowserNewWindowHandler(FormBrowser_FormBrowserNewWindow);
            FormConfig.SetGlobalKey+=new GlobleKeySetHandler(FormConfig_SetGlobalKey);
            FormBrowserContainer.TabAllClosed+=new TabAllClosedHandler(FormBrowserContainer_TabAllClosed);
            FormBrowserContainer.FormSizeChanged+=new FormSizeChangedHandler(FormBrowserContainer_FormSizeChanged);
            FormEyeGuard.EventEyeGuard+=new HandleEyeGuard(FormEyeGuard_EventEyeGuard);            
            bwInit = new BackgroundWorker();
            bwInit.DoWork += new DoWorkEventHandler(bwInit_DoWork);
            bwInit.RunWorkerAsync();//执行耗时操作，避免界面无响应
        }
        //系统加载事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            int startx = MainFormStartPosition.X - Convert.ToInt32(((float)fbc.Width - (float)this.Width) / 2.0f);
            int starty = MainFormStartPosition.Y - fbc.Height;
            WebFormStartPosition.X = startx;
            WebFormStartPosition.Y = starty;

            MainFormCollapsed();
            try
            {
                //fswUserInput = new FileStream("UserInput.log", FileMode.Open, FileAccess.Write);
                //fsrUserInput = new FileStream("UserInput.log", FileMode.Open, FileAccess.Read);
                //swUserInput = new StreamWriter(fswUserInput);
                //srUserInput = new StreamReader(fsrUserInput);
                flagGlobalHotKeySet = HotKey.RegisterHotKey(this.Handle, WIN_S, HotKey.KeyModifiers.WindowsKey, Keys.S);
                flagGlobalHotKeySet=HotKey.RegisterHotKey(this.Handle, CTL_ALT_A, HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Ctrl, Keys.A);
                flagGlobalHotKeySet = HotKey.RegisterHotKey(this.Handle, CTL_ALT_SHIFT_S, HotKey.KeyModifiers.Shift| HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Ctrl, Keys.S);
                flagGlobalHotKeySet = HotKey.RegisterHotKey(this.Handle, CTL_ALT_SHIFT_X, HotKey.KeyModifiers.Shift|HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Ctrl, Keys.X);
                flagGlobalHotKeySet = HotKey.RegisterHotKey(this.Handle, CTL_ALT_SHIFT_R, HotKey.KeyModifiers.Shift | HotKey.KeyModifiers.Alt | HotKey.KeyModifiers.Ctrl, Keys.R);
                flagGlobalHotKeySet = HotKey.RegisterHotKey(this.Handle, WIN_F12, HotKey.KeyModifiers.WindowsKey, Keys.F12);
                if (!flagGlobalHotKeySet)
                {
                    throw new Exception("注册全局快捷键失败!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "出错了");
            }
        }
        //启动时后台运行的程序
        private void bwInit_DoWork(object sender, DoWorkEventArgs e)
        {            
            //... 创建目录、读取文件、生成快捷方式
            //创建应用程序配置目录
            string dirAppData = Environment.SpecialFolder.ApplicationData.ToString();
            if (Directory.Exists(dirAppData))
            { 
                
            }
            //开机启动及生成桌面快捷方式
            if (FuncLib.CheckStartUPSet())
            {
                //创建快捷方式s
                FuncLib.CreateDesktopLnk(DISPLAY_NAME);
                toolStripMenuItemStartUp.Checked = true;
            }
            ////加入系统启动项
            //if (FuncLib.SetStartUp(true, exeName))
            //{
            //    toolStripMenuItemStartUp.Checked = true;
            //}
        }
        #endregion
        #region 网络通信
        private void InitUdpCommServer()
        {
            udpCommServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipeComm = new IPEndPoint(IPAddress.Any, PORT_COMM);
            udpCommServer.Bind(ipeComm);
            ThreadPool.QueueUserWorkItem(this.HandleUdpComm, ipeComm);
        }

        private void InitUdpMsgServer()
        {
            udpMsgServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipeMsg = new IPEndPoint(IPAddress.Any, PORT_COMM);
            udpMsgServer.Bind(ipeMsg);
            ThreadPool.QueueUserWorkItem(this.HandleUdpMsg, ipeMsg);
        }

        private void InitUdpFileServer()
        {
            udpFileServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipeFile = new IPEndPoint(IPAddress.Any, PORT_COMM);
            udpFileServer.Bind(ipeFile);
            ThreadPool.QueueUserWorkItem(this.HandleUdpFile, ipeFile);
        }

        private void HandleUdpComm(object state)
        {

        }

        private void HandleUdpMsg(object state)
        {

        }

        private void HandleUdpFile(object state)
        {

        }

        #endregion
        #region 界面相关

        private void SearchInNewWindow(EnumSearchEngine enumSE)
        {
            if (fbc==null||fbc.Visible==false)
            {
                fbc = new FormBrowserContainer();
                fbc.StartPosition = FormStartPosition.Manual;
                fbc.Location = new Point(WebFormStartPosition.X, WebFormStartPosition.Y);
                fbc.ShowInTaskbar = false;
                fbc.Show();
            }

            fbc.BringToFront();
            fb = new FormBrowser(tbSearch.Text, enumSE);
            fb.Dock = DockStyle.Fill;
            //将搜索文本存入文件流
            //swUserInput.WriteLine(DateTime.Now.ToString("yy-MM-dd_HH:mm:ss"+" "+fb.searchstr));
            //fb.enumSE = enumSE;
            fbc.AddNewTab(fb);
            listFormBrowser.Add(fb);
        }

        private void ShowHelpForm(int type)
        {
            fh = new FormHelp();
            fh.ShowInTaskbar = false;
            fh.ShowIcon = false;
            switch (type)
            {
                case 0:
                    {
                        
                        fh.StartPosition = FormStartPosition.Manual;
                        fh.Location = new Point(this.Location.X - (fh.Width / 2 - this.Width / 2), this.Location.Y - fh.Height);
                        fh.Show();
                    }
                    break;
                case 1:
                    {
                        fh.StartPosition = FormStartPosition.CenterScreen;
                        fh.Location = new Point(this.Location.X - (fh.Width / 2 - this.Width / 2), this.Location.Y - fh.Height);
                        fh.Show();
                    }
                    break;
            }
            
        }
        
        private void MainFormExpand()
        {
            this.Size = new Size(584, 64);
            flagFormExpand = true;
            this.Refresh();
        }

        private void MainFormCollapsed()
        {
            this.Size = new Size(584, 40);
            flagFormExpand = false;
            this.Refresh();
        }

        private void ShowMainForm()
        {
            this.Visible = true;
            toolStripMenuItemDisplay.Text = "隐藏界面";
            flagFormShow = true;
        }

        private void HideMainForm()
        {
            this.Visible = false;
            toolStripMenuItemDisplay.Text = "显示界面";
            flagFormShow = false;
            
        }

        private void frmToMiddle()
        {
            //...动画效果
            this.Location = MainFormStartPosition;
            //FormEffect.Swift(this);
            flagFormDocked = false;
            if (fbc != null)
            {
                //fbc.Visible = true;
                fbc.BringToFront();
            }
            this.BringToFront();
            this.Activate();
            this.Visible = true;
            tbSearch.Focus();
        }

        private void frmToDock()
        {
            //...动画效果
            this.Location = new Point(MAIN_FORM_DOCK_X, MainFormStartPosition.Y);
            flagFormDocked = true;
            ckbDock.Checked = true;

            if (fbc != null)
            {
                //fbc.Visible = false;
                fbc.SendToBack();
            }
            if (!flagFormShow)
            {
                this.Visible = false;
            }
            //收起搜索引擎设置界面
            if (flagFormExpand)
            {
                flagFormExpand = false;
                MainFormCollapsed();
                ckbShowSE.Checked = false;
            }
        }
        #endregion
        #region 右键菜单
        //退出程序
        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出本软件？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            Application.Exit();
        }
        //显示隐藏
        private void toolStripMenuItemDisplay_Click(object sender, EventArgs e)
        {
            if (flagFormShow)
            {
                HideMainForm();
            }
            else
            {
                ShowMainForm();
            }
        }
        //帮助窗口
        private void toolStripMenuItemHelp_Click(object sender, EventArgs e)
        {
            if (flagFormDocked)
            {
                ShowHelpForm(1);
            }
            else
            {
                ShowHelpForm(0);                
            }
        }
        //开机启动
        private void toolStripMenuItemStartUp_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemStartUp.Checked)//设置开机不启动
            {
                if (FuncLib.SetStartUp(false, exeName))
                {
                    MessageBox.Show("取消开机启动成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    toolStripMenuItemStartUp.Checked = false;
                }
                else
                {
                    MessageBox.Show("取消开机启动失败","提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else//设置开机启动
            {
                if (FuncLib.CheckStartUPSet())
                {
                    MessageBox.Show("设置开机启动成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    toolStripMenuItemStartUp.Checked = true;
                }
                else
                {
                    MessageBox.Show("设置开机启动失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //生成快捷方式
        private void toolStripMenuItemShortCut_Click(object sender, EventArgs e)
        {
            if (FuncLib.CreateDesktopLnk(DISPLAY_NAME))
            {
                MessageBox.Show("创建快捷方式到桌面成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("创建快捷方式到桌面失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //护眼模式控制
        private void tmiEyeGuard_Click(object sender, EventArgs e)
        {
            if (flagEyeGuardOpen)
            {
                feyeGuard.StopEyeGuard();
                flagEyeGuardOpen = false;
                tmiEyeGuard.Text = "开启护眼";
                prbEyeGuardInterval.Visible = false;
                return;
            }
            feyeGuard.flagEyeGuard = false;
            if(feyeGuard.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                prbEyeGuardInterval.Maximum = feyeGuard.nRestInterval;
                prbEyeGuardInterval.Visible = true;
                tmiEyeGuard.Text = "停止护眼";
                flagEyeGuardOpen = true;
            }
        }
        //系统设置
        private void tmiSystemSet_Click(object sender, EventArgs e)
        {
            FormConfig fc = new FormConfig();
            fc.StartPosition = FormStartPosition.CenterScreen;
            fc.ShowDialog(this);
        }
        //截屏
        private void tmiCaptrueScreen_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }
        //系统关机
        private void tmiSystemShutDown_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定关闭计算机？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.OK)
            WindowsController.ExitWindows(RestartOptions.ShutDown, true);
        }
        //系统重启
        private void tmiSystemRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定重启计算机？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            WindowsController.ExitWindows(RestartOptions.Reboot, true);
        }
        //系统注销
        private void tmiSystemLogoff_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定注销计算机？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            WindowsController.ExitWindows(RestartOptions.LogOff, true);
        }
        //系统休眠
        private void tmiSystemHibernate_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("确定休眠计算机？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            WindowsController.ExitWindows(RestartOptions.Hibernate, true);
        }
        //系统睡眠/挂起
        private void tmiSystemSleep_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定挂起计算机？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            WindowsController.ExitWindows(RestartOptions.Suspend, true);
        }
        //闹钟设置
        private void tmiAlarmClockSet_Click(object sender, EventArgs e)
        {
            FormAlarmClockSet fac = new FormAlarmClockSet();
            fac.StartPosition = FormStartPosition.CenterScreen;
            fac.ShowDialog();
        }
        #endregion
        #region 事件集合
        private void MainForm_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt)
            {
                if (cdgMainForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.BackColor = cdgMainForm.Color;
                }
            }
        }

        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            if (fbc != null)
            {
                fbc.BringToFront();
                fbc.Focus();
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                FuncLib.StartDrag(this.Handle);
            }
        }

        private void ckbDock_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbDock.Checked)
            {
                frmToDock();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sb1 = new SolidBrush(Color.LightGray);
            SolidBrush sb2 = new SolidBrush(Color.Gray);
            Pen p1 = new Pen(sb1);
            Pen p2= new Pen(sb2);
            g.DrawRectangle(p2, 0, 0, this.Width - 1, this.Height - 1);
            g.DrawLine(p1, 0, 0, this.Width - 1, 0);
            g.DrawLine(p1,0,0,0,this.Height-1);
            //g.DrawLine(p2,this.Width-1,0,this.Width-1,this.Height-1);
            sb1.Dispose();
            sb2.Dispose();
            p1.Dispose();
            p2.Dispose();
            g.Dispose();
        }
        
        private void FormBrowserContainer_TabAllClosed(object sender)
        {
            fbc.Close();
            fbc = null;
        }

        private void FormConfig_SetGlobalKey(object sender)
        {
            if (flagGlobalHotKeySet)
            {
                MessageBox.Show("全局快捷键Win+S已经注册成功", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                flagGlobalHotKeySet = HotKey.RegisterHotKey(Handle, WIN_S, HotKey.KeyModifiers.WindowsKey, Keys.S);
                if (!flagGlobalHotKeySet)
                {
                    MessageBox.Show("注册全局快捷键Win+S失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormBrowser_HandleBackFormBrowserMaximized(FormWindowState fws)
        {
            switch (fws)
            {
                case FormWindowState.Maximized:
                    //将主搜索框停靠
                    if (!flagFormDocked)
                    {
                        frmToDock();
                    }
                    break;
                case FormWindowState.Normal:
                    if (flagFormDocked)
                    {
                        frmToMiddle();
                    }
                    break;
            }
        }
        //收到某个浏览器窗体关闭事件
        private void FormBrowser_HandleBackFormBrowserClosed(object sender)
        {
            FormBrowser fb=sender as FormBrowser;
            //int index = GetFormBrowserIndex(fb);
            //listFormBrowser.RemoveAt(index);
            listFormBrowser.Remove(fb);
        }

        private int GetFormBrowserIndex(FormBrowser fb)
        {
            return listFormBrowser.FindIndex(delegate(FormBrowser ent)
            {
                return ent.Equals(fb);
            });
        }

        private void rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGoogleWeb.Checked)
            {
                enumCurrentSE = EnumSearchEngine.GOOGLE_WEB;
                //lbSEType.Text = "谷歌";
            }
            else if (rdbBaiduWeb.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_WEB;
                //lbSEType.Text="百度";
            }
            else if (rdbBaiduBaike.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_BAIKE;
                //lbSEType.Text = "百科";
            }
            else if (rdbBaiduZhiDao.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_ZHIDAO;
                //lbSEType.Text = "知道";
            }
            else if (rdbBaiduMusic.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_MUSIC;
                //lbSEType.Text = "音乐";
            }
            else if (rdbBaiduApp.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_APP;
                //lbSEType.Text = "应用";
            }
            else if (rdbIcon.Checked)
            {
                enumCurrentSE = EnumSearchEngine.ICON_EASY;
                //lbSEType.Text = "图标";                
            }
            else if (rdbBaiduWenKu.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_WENKU;
                //lbSEType.Text = "文库";
            }
            else if (rdbBaiduMap.Checked)
            {
                enumCurrentSE = EnumSearchEngine.BAIDU_MAP;
                //lbSEType.Text = "地图";
            }
            else if (rdbFanyi.Checked)
            {
                enumCurrentSE = EnumSearchEngine.GOOGLE_FANYI;
            }
        }

        private void ckbShowSE_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowSE.Checked)
            {
                MainFormExpand();
            }
            else
            {
                MainFormCollapsed();
            }
        }

        private void ntiMain_DoubleClick(object sender, EventArgs e)
        {
            if (flagFormDocked)
            {
                frmToMiddle();
            }
            else
            {
                frmToDock();
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100://win+s
                            this.Visible = true;
                            if (flagFormDocked)
                            {
                                frmToMiddle();
                            }
                            else
                            {
                                if (listFormBrowser.Count > 0 || tbSearch.Focused == false)//已经打开子窗口，让主窗口重新聚焦
                                {
                                    if (fbc != null)
                                    {
                                        fbc.BringToFront();
                                        fbc.Activate();
                                    }
                                    this.BringToFront();
                                    this.Activate();
                                    tbSearch.Focus();
                                }
                                else
                                {
                                frmToDock();
                                }
                            }
                            break;
                        case CTL_ALT_A://ctrl+alt+a 截屏
                            {
                                CaptureScreen();
                            }
                            break;
                        case CTL_ALT_SHIFT_X:
                            {
                                tmiSystemShutDown_Click(null, null);
                            }
                            break;
                        case CTL_ALT_SHIFT_S:
                            {
                                tmiSystemHibernate_Click(null, null);
                            }
                            break;
                        case CTL_ALT_SHIFT_R:
                            {
                                tmiSystemRestart_Click(null,null);
                            }
                            break;
                        case WIN_F12:
                            {
                                SetWindowBlack();
                            }
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
      
        private void tbSearch_DoubleClick(object sender, EventArgs e)
        {
            tbSearch.SelectAll();
        }

        private void fb_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), 0, 0, 119, 94);
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        //MessageBox.Show("按下enter");
                        break;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)//恢复默认图标
            {
                btnSearch.Image = global::DeskTopOnline.Properties.Resources.zinnami_32;
                return;
            }
            if (Control.ModifierKeys == Keys.Alt)//更换图标
            {
                //if (ofdChangeIcon.ShowDialog() == System.Windows.Forms.DialogResult.OK)//更换图标
                //{
                //    try
                //    {
                //        //将图标拷贝到配置目录中去
                //        //替换图标
                //        Bitmap img = new Bitmap(ofdChangeIcon.FileName);                       
                //        //img.SetResolution(16f, 16f);
                //        //btnSearch.Image = Image.FromFile(ofdChangeIcon.FileName);
                //        btnSearch.Image = img;
                //    }
                //    catch(Exception ex)
                //    {
                //        MessageBox.Show(ex.Message,"异常");
                //    }
                //}
                FormPortraitGenerator fpg = new FormPortraitGenerator();
                if (flagFormDocked)
                {
                    fpg.StartPosition = FormStartPosition.CenterScreen;
                }
                else
                {
                    fpg.StartPosition = FormStartPosition.Manual;
                    fpg.Location = new Point(this.Location.X - (fpg.Width / 2 - this.Width / 2), this.Location.Y - fpg.Height);
                }
                if (fpg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    btnSearch.Image = fpg.GeneratedImg;
                    fpg.Close();
                }
            }
            else
            {
                if (flagFormDocked)//缩进状态先弹出来
                {
                    frmToMiddle();
                }
                else
                {
                    if (tbSearch.Text.Trim(' ') == "")
                    {
                        tbSearch.Text = "";
                        frmToDock();
                        return;
                    }
                    if (FuncLib.IsURL(tbSearch.Text) || FuncLib.IsURL(@"http://" + tbSearch.Text))
                    {
                        enumCurrentSE = EnumSearchEngine.OPEN_URL;
                    }
                    SearchInNewWindow(enumCurrentSE);
                }
            }
        }

        //private void MainForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //ctrl组合键
        //    if (e.Control && !e.Shift && !e.Alt)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter://使用google搜索
        //                //lbSEType.Text = "谷歌";
        //                enumCurrentSE = EnumSearchEngine.GOOGLE_WEB;
        //                break;
        //            //case Keys.Enter://使用百度搜索
        //            //    if (tbSearch.Text == "")
        //            //        return;
        //            //    SearchInNewWindow(EnumSearchEngine.BAIDU_WEB);
        //            //    break;                   
        //            case Keys.I:
        //                //lbSEType.Text = "图标";
        //                enumCurrentSE = EnumSearchEngine.ICON_EASY;
        //                break;
        //        }
        //    }
        //    //alt组合键
        //    if (e.Alt && !e.Shift && !e.Control)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "百度";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_WEB;

        //                break;
        //        }
        //    }

        //    //shift 组合键
        //    if (e.Shift && !e.Control && !e.Alt)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "知道";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_ZHIDAO;

        //                break;
        //        }
        //    }

        //    //ctrl+shift组合键
        //    if (e.Control && e.Shift && !e.Alt)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "百科";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_BAIKE;
        //                break;
        //        }
        //    }
        //    //ctrl+alt组合键
        //    if (e.Control && e.Alt && !e.Shift)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "音乐";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_MUSIC;
        //                break;
        //        }
        //    }
        //    //alt+shift组合键
        //    if (e.Alt && e.Shift && !e.Control)
        //    {

        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "文库";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_WENKU;
        //                break;

        //        }
        //    }
        //    //ctrl+alt+shift组合键
        //    if (e.Control && e.Alt && e.Shift)
        //    {
        //        switch (e.KeyCode)
        //        {
        //            case Keys.Enter:
        //                //lbSEType.Text = "地图";
        //                enumCurrentSE = EnumSearchEngine.BAIDU_MAP;
        //                break;
        //        }
        //    }
        //}

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            //未按下组合键
            if ((e.Shift | e.Control | e.Alt) != true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape://原Escape收起改为Win+S收起
                        //this.Close();
                        //this.Location = new Point(btnSearch.Location.X-this.Location.X,this.Location.Y);
                        frmToDock();
                        break;
                    case Keys.Enter://Enter键开始搜索
                        //if (!tbSearch.Focused)
                        //{
                            btnSearch_Click(null, null);
                        //}
                        break;
                    case Keys.F1:
                        toolStripMenuItemHelp_Click(null,null);
                        break;
                    //case Keys.Enter:
                    //    if (tbSearch.Text == "")
                    //        return;
                    //    SearchInNewWindow(EnumSearchEngine.GOOGLE_WEB);
                    //    break;
                }
            }
            //ctrl组合键
            if (e.Control && !e.Shift && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        tbSearch.SelectAll();
                        break;
                    case Keys.W:
                        if (listFormBrowser.Count >= 1)
                        {
                            listFormBrowser[listFormBrowser.Count - 1].Dispose();//关闭最后一个窗体
                        }
                        break;
                    case Keys.S:
                        ckbShowSE.Checked = !ckbShowSE.Checked;
                        break;
                    case Keys.Enter://使用google搜索
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.GOOGLE_WEB);
                        SetSEChoice(EnumSearchEngine.GOOGLE_WEB);
                        break;
                    //case Keys.Enter://使用百度搜索
                    //    if (tbSearch.Text == "")
                    //        return;
                    //    SearchInNewWindow(EnumSearchEngine.BAIDU_WEB);
                    //    break;
                    case Keys.Back:
                        tbSearch.Clear();
                        break;
                    case Keys.I:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.ICON_EASY);
                        SetSEChoice(EnumSearchEngine.ICON_EASY);
                        break;
                }
            }
            //alt组合键
            if (e.Alt && !e.Shift && !e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_WEB);
                        SetSEChoice(EnumSearchEngine.BAIDU_WEB);
                        break;
                }
            }

            //shift 组合键
            if (e.Shift && !e.Control && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_ZHIDAO);
                        SetSEChoice(EnumSearchEngine.BAIDU_ZHIDAO);
                        break;
                }
            }

            //ctrl+shift组合键
            if (e.Control && e.Shift && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_BAIKE);
                        SetSEChoice(EnumSearchEngine.BAIDU_BAIKE);
                        break;
                    case Keys.W:
                        if (fbc != null)
                        {
                            fbc.Close();
                        }
                        listFormBrowser.Clear();
                        break;
                }
            }
            //ctrl+alt组合键
            if (e.Control && e.Alt && !e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_MUSIC);
                        SetSEChoice(EnumSearchEngine.BAIDU_MUSIC);
                        break;
                }
            }
            //alt+shift组合键
            if (e.Alt && e.Shift && !e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_WENKU);
                        SetSEChoice(EnumSearchEngine.BAIDU_WENKU);
                        break;
                }
            }
            //ctrl+alt+shift组合键
            if (e.Control && e.Alt && e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (tbSearch.Text == "")
                            return;
                        SearchInNewWindow(EnumSearchEngine.BAIDU_MAP);
                        SetSEChoice(EnumSearchEngine.BAIDU_MAP);
                        break;
                }
            }
        }

        private void FormEyeGuard_EventEyeGuard(int n)
        {
            prbEyeGuardInterval.Invoke(new EventHandler(delegate
            {
                prbEyeGuardInterval.Value = n;
                if (n < 60)
                {
                    FormEffect.Blink(this);
                }
            }));
        }

        private void FormBrowserContainer_FormSizeChanged(FormWindowState fws)
        {
            if (fws == FormWindowState.Maximized)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
        }

        private void FormBrowser_FormBrowserNewWindow(string url)
        {
            fb = new FormBrowser(url, EnumSearchEngine.OPEN_URL);
            fb.Dock = DockStyle.Fill;
            //将搜索文本存入文件流
            //swUserInput.WriteLine(DateTime.Now.ToString("yy-MM-dd_HH:mm:ss"+" "+fb.searchstr));
            //fb.enumSE = enumSE;
            fbc.AddNewTab(fb);
            listFormBrowser.Add(fb);
        }
        #endregion
        #region 功能函数
        //黑屏
        private void SetWindowBlack()
        {
            FormRestScreen fmRest = new FormRestScreen();
            fmRest.TotalRestTime = 5;
            fmRest.ShowDialog();
        }
        //截屏
        private void CaptureScreen()
        {
            if (flagFormShow)
            {
                this.Hide();
            }
            Thread.Sleep(20);
            CaptureImageTool cit = new CaptureImageTool();
            cit.ShowDialog();
            if (flagFormShow)
            {
                this.Show();
            }
        }
        //设置搜索引擎
        private void SetSEChoice(EnumSearchEngine ese)
        {
            switch (ese)
            {
                case EnumSearchEngine.GOOGLE_WEB:
                    rdbGoogleWeb.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_WEB:
                    rdbBaiduWeb.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_ZHIDAO:
                    rdbBaiduZhiDao.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_BAIKE:
                    rdbBaiduBaike.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_WENKU:
                    rdbBaiduWenKu.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_MUSIC:
                    rdbBaiduMusic.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_MAP:
                    rdbBaiduMap.Checked = true;
                    break;
                case EnumSearchEngine.BAIDU_APP:
                    rdbBaiduApp.Checked = true;
                    break;
                case EnumSearchEngine.ICON_EASY:
                    rdbIcon.Checked = true;
                    break;
                case EnumSearchEngine.LOCAL_FILE:
                    rdbFanyi.Checked = true;
                    break;
            }
        }
        //获取搜索引擎
        private EnumSearchEngine GetSEChoice()
        {
            EnumSearchEngine ese = new EnumSearchEngine();
            if (rdbGoogleWeb.Checked)
            {
                ese = EnumSearchEngine.GOOGLE_WEB;
            }
            else if (rdbBaiduWeb.Checked)
            {
                ese = EnumSearchEngine.BAIDU_WEB;
            }
            else if (rdbBaiduZhiDao.Checked)
            {
                ese = EnumSearchEngine.BAIDU_ZHIDAO;
            }
            else if (rdbBaiduBaike.Checked)
            {
                ese = EnumSearchEngine.BAIDU_BAIKE;
            }
            else if (rdbBaiduMap.Checked)
            {
                ese = EnumSearchEngine.BAIDU_MAP;
            }
            else if (rdbFanyi.Checked)
            {
                ese = EnumSearchEngine.LOCAL_FILE;
            }
            else if (rdbBaiduMusic.Checked)
            {
                ese = EnumSearchEngine.BAIDU_MUSIC;
            }
            return ese;
        }
        #endregion
        #region 资源释放
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotKey.UnregisterHotKey(this.Handle, WIN_S);
            HotKey.UnregisterHotKey(this.Handle,CTL_ALT_A);
            HotKey.UnregisterHotKey(this.Handle,CTL_ALT_SHIFT_S);
            HotKey.UnregisterHotKey(this.Handle,CTL_ALT_SHIFT_X);
            HotKey.UnregisterHotKey(this.Handle,CTL_ALT_SHIFT_R);
            HotKey.UnregisterHotKey(this.Handle,WIN_F12);
        }
        #endregion
    }
}