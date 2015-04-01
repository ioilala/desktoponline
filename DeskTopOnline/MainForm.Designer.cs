namespace DeskTopOnline
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.ntiMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemManage = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemShutDown = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemSleep = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemRestart = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemHibernate = new System.Windows.Forms.ToolStripMenuItem();
            this.功能组件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCaptureScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEyeGuard = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiAlarmClockSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSoftWareSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiShortCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiSystemSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbBaiduWenKu = new System.Windows.Forms.RadioButton();
            this.rdbIcon = new System.Windows.Forms.RadioButton();
            this.rdbFanyi = new System.Windows.Forms.RadioButton();
            this.rdbBaiduApp = new System.Windows.Forms.RadioButton();
            this.rdbBaiduMap = new System.Windows.Forms.RadioButton();
            this.rdbBaiduMusic = new System.Windows.Forms.RadioButton();
            this.rdbBaiduBaike = new System.Windows.Forms.RadioButton();
            this.rdbBaiduZhiDao = new System.Windows.Forms.RadioButton();
            this.rdbBaiduWeb = new System.Windows.Forms.RadioButton();
            this.rdbGoogleWeb = new System.Windows.Forms.RadioButton();
            this.ckbShowSE = new System.Windows.Forms.CheckBox();
            this.ckbDock = new System.Windows.Forms.CheckBox();
            this.prbEyeGuardInterval = new System.Windows.Forms.ProgressBar();
            this.ofdChangeIcon = new System.Windows.Forms.OpenFileDialog();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cdgMainForm = new System.Windows.Forms.ColorDialog();
            this.cmsMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.White;
            this.tbSearch.Font = new System.Drawing.Font("Verdana", 11F);
            this.tbSearch.Location = new System.Drawing.Point(22, 6);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(521, 25);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // ntiMain
            // 
            this.ntiMain.ContextMenuStrip = this.cmsMain;
            this.ntiMain.Icon = ((System.Drawing.Icon)(resources.GetObject("ntiMain.Icon")));
            this.ntiMain.Text = "桌面在线1.1.2";
            this.ntiMain.Visible = true;
            this.ntiMain.DoubleClick += new System.EventHandler(this.ntiMain_DoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDisplay,
            this.tmiSystemManage,
            this.功能组件ToolStripMenuItem,
            this.tmiSoftWareSet,
            this.toolStripMenuItemQuit});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(153, 136);
            // 
            // toolStripMenuItemDisplay
            // 
            this.toolStripMenuItemDisplay.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItemDisplay.Image = global::DeskTopOnline.Properties.Resources.album_search;
            this.toolStripMenuItemDisplay.Name = "toolStripMenuItemDisplay";
            this.toolStripMenuItemDisplay.ShortcutKeyDisplayString = "";
            this.toolStripMenuItemDisplay.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemDisplay.Text = "隐藏界面";
            this.toolStripMenuItemDisplay.Click += new System.EventHandler(this.toolStripMenuItemDisplay_Click);
            // 
            // tmiSystemManage
            // 
            this.tmiSystemManage.BackColor = System.Drawing.Color.White;
            this.tmiSystemManage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiSystemShutDown,
            this.tmiSystemSleep,
            this.tmiSystemRestart,
            this.tmiSystemLogoff,
            this.tmiSystemHibernate});
            this.tmiSystemManage.Image = global::DeskTopOnline.Properties.Resources.systemmanage;
            this.tmiSystemManage.Name = "tmiSystemManage";
            this.tmiSystemManage.Size = new System.Drawing.Size(152, 22);
            this.tmiSystemManage.Text = "系统控制";
            // 
            // tmiSystemShutDown
            // 
            this.tmiSystemShutDown.BackColor = System.Drawing.Color.White;
            this.tmiSystemShutDown.Name = "tmiSystemShutDown";
            this.tmiSystemShutDown.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.X)));
            this.tmiSystemShutDown.Size = new System.Drawing.Size(188, 22);
            this.tmiSystemShutDown.Text = "关机";
            this.tmiSystemShutDown.Click += new System.EventHandler(this.tmiSystemShutDown_Click);
            // 
            // tmiSystemSleep
            // 
            this.tmiSystemSleep.BackColor = System.Drawing.Color.White;
            this.tmiSystemSleep.Name = "tmiSystemSleep";
            this.tmiSystemSleep.Size = new System.Drawing.Size(188, 22);
            this.tmiSystemSleep.Text = "挂起";
            this.tmiSystemSleep.Click += new System.EventHandler(this.tmiSystemSleep_Click);
            // 
            // tmiSystemRestart
            // 
            this.tmiSystemRestart.BackColor = System.Drawing.Color.White;
            this.tmiSystemRestart.Name = "tmiSystemRestart";
            this.tmiSystemRestart.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.R)));
            this.tmiSystemRestart.Size = new System.Drawing.Size(188, 22);
            this.tmiSystemRestart.Text = "重启";
            this.tmiSystemRestart.Click += new System.EventHandler(this.tmiSystemRestart_Click);
            // 
            // tmiSystemLogoff
            // 
            this.tmiSystemLogoff.BackColor = System.Drawing.Color.White;
            this.tmiSystemLogoff.Name = "tmiSystemLogoff";
            this.tmiSystemLogoff.Size = new System.Drawing.Size(188, 22);
            this.tmiSystemLogoff.Text = "注销";
            this.tmiSystemLogoff.Click += new System.EventHandler(this.tmiSystemLogoff_Click);
            // 
            // tmiSystemHibernate
            // 
            this.tmiSystemHibernate.BackColor = System.Drawing.Color.White;
            this.tmiSystemHibernate.Name = "tmiSystemHibernate";
            this.tmiSystemHibernate.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.tmiSystemHibernate.Size = new System.Drawing.Size(188, 22);
            this.tmiSystemHibernate.Text = "休眠";
            this.tmiSystemHibernate.Click += new System.EventHandler(this.tmiSystemHibernate_Click);
            // 
            // 功能组件ToolStripMenuItem
            // 
            this.功能组件ToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.功能组件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiCaptureScreen,
            this.tmiEyeGuard,
            this.tmiAlarmClockSet});
            this.功能组件ToolStripMenuItem.Image = global::DeskTopOnline.Properties.Resources.plugin;
            this.功能组件ToolStripMenuItem.Name = "功能组件ToolStripMenuItem";
            this.功能组件ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.功能组件ToolStripMenuItem.Text = "功能组件";
            // 
            // tmiCaptureScreen
            // 
            this.tmiCaptureScreen.BackColor = System.Drawing.Color.White;
            this.tmiCaptureScreen.Image = global::DeskTopOnline.Properties.Resources.capturescreen;
            this.tmiCaptureScreen.Name = "tmiCaptureScreen";
            this.tmiCaptureScreen.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt)
                        | System.Windows.Forms.Keys.A)));
            this.tmiCaptureScreen.Size = new System.Drawing.Size(182, 22);
            this.tmiCaptureScreen.Text = "手动截屏";
            this.tmiCaptureScreen.Click += new System.EventHandler(this.tmiCaptrueScreen_Click);
            // 
            // tmiEyeGuard
            // 
            this.tmiEyeGuard.BackColor = System.Drawing.Color.White;
            this.tmiEyeGuard.Image = global::DeskTopOnline.Properties.Resources.eyeGuard;
            this.tmiEyeGuard.Name = "tmiEyeGuard";
            this.tmiEyeGuard.Size = new System.Drawing.Size(182, 22);
            this.tmiEyeGuard.Text = "开启护眼";
            this.tmiEyeGuard.Click += new System.EventHandler(this.tmiEyeGuard_Click);
            // 
            // tmiAlarmClockSet
            // 
            this.tmiAlarmClockSet.BackColor = System.Drawing.Color.White;
            this.tmiAlarmClockSet.Image = global::DeskTopOnline.Properties.Resources.clock;
            this.tmiAlarmClockSet.Name = "tmiAlarmClockSet";
            this.tmiAlarmClockSet.Size = new System.Drawing.Size(182, 22);
            this.tmiAlarmClockSet.Text = "设定闹钟";
            this.tmiAlarmClockSet.Click += new System.EventHandler(this.tmiAlarmClockSet_Click);
            // 
            // tmiSoftWareSet
            // 
            this.tmiSoftWareSet.BackColor = System.Drawing.Color.White;
            this.tmiSoftWareSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiShortCut,
            this.toolStripMenuItemStartUp,
            this.tmiHelp,
            this.tmiSystemSet});
            this.tmiSoftWareSet.Image = global::DeskTopOnline.Properties.Resources.softwareset;
            this.tmiSoftWareSet.Name = "tmiSoftWareSet";
            this.tmiSoftWareSet.Size = new System.Drawing.Size(152, 22);
            this.tmiSoftWareSet.Text = "软件设置";
            // 
            // tmiShortCut
            // 
            this.tmiShortCut.BackColor = System.Drawing.Color.White;
            this.tmiShortCut.Image = global::DeskTopOnline.Properties.Resources.shortcut;
            this.tmiShortCut.Name = "tmiShortCut";
            this.tmiShortCut.Size = new System.Drawing.Size(122, 22);
            this.tmiShortCut.Text = "快捷方式";
            this.tmiShortCut.Click += new System.EventHandler(this.toolStripMenuItemShortCut_Click);
            // 
            // toolStripMenuItemStartUp
            // 
            this.toolStripMenuItemStartUp.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItemStartUp.Name = "toolStripMenuItemStartUp";
            this.toolStripMenuItemStartUp.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItemStartUp.Text = "开机启动";
            this.toolStripMenuItemStartUp.Click += new System.EventHandler(this.toolStripMenuItemStartUp_Click);
            // 
            // tmiHelp
            // 
            this.tmiHelp.BackColor = System.Drawing.Color.White;
            this.tmiHelp.Image = global::DeskTopOnline.Properties.Resources.symbol_question;
            this.tmiHelp.Name = "tmiHelp";
            this.tmiHelp.Size = new System.Drawing.Size(122, 22);
            this.tmiHelp.Text = "软件帮助";
            this.tmiHelp.Click += new System.EventHandler(this.toolStripMenuItemHelp_Click);
            // 
            // tmiSystemSet
            // 
            this.tmiSystemSet.BackColor = System.Drawing.Color.White;
            this.tmiSystemSet.Image = global::DeskTopOnline.Properties.Resources.settings;
            this.tmiSystemSet.Name = "tmiSystemSet";
            this.tmiSystemSet.Size = new System.Drawing.Size(122, 22);
            this.tmiSystemSet.Text = "系统设置";
            this.tmiSystemSet.Click += new System.EventHandler(this.tmiSystemSet_Click);
            // 
            // toolStripMenuItemQuit
            // 
            this.toolStripMenuItemQuit.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItemQuit.Image = global::DeskTopOnline.Properties.Resources.album_left;
            this.toolStripMenuItemQuit.Name = "toolStripMenuItemQuit";
            this.toolStripMenuItemQuit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItemQuit.Text = "退出程序";
            this.toolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItemQuit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.rdbBaiduWenKu);
            this.panel3.Controls.Add(this.rdbIcon);
            this.panel3.Controls.Add(this.rdbFanyi);
            this.panel3.Controls.Add(this.rdbBaiduApp);
            this.panel3.Controls.Add(this.rdbBaiduMap);
            this.panel3.Controls.Add(this.rdbBaiduMusic);
            this.panel3.Controls.Add(this.rdbBaiduBaike);
            this.panel3.Controls.Add(this.rdbBaiduZhiDao);
            this.panel3.Controls.Add(this.rdbBaiduWeb);
            this.panel3.Controls.Add(this.rdbGoogleWeb);
            this.panel3.Location = new System.Drawing.Point(37, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(489, 28);
            this.panel3.TabIndex = 10;
            // 
            // rdbBaiduWenKu
            // 
            this.rdbBaiduWenKu.AutoSize = true;
            this.rdbBaiduWenKu.Location = new System.Drawing.Point(292, 7);
            this.rdbBaiduWenKu.Name = "rdbBaiduWenKu";
            this.rdbBaiduWenKu.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduWenKu.TabIndex = 9;
            this.rdbBaiduWenKu.Text = "文库";
            this.rdbBaiduWenKu.UseVisualStyleBackColor = true;
            this.rdbBaiduWenKu.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbIcon
            // 
            this.rdbIcon.AutoSize = true;
            this.rdbIcon.Location = new System.Drawing.Point(388, 7);
            this.rdbIcon.Name = "rdbIcon";
            this.rdbIcon.Size = new System.Drawing.Size(47, 16);
            this.rdbIcon.TabIndex = 11;
            this.rdbIcon.Text = "图标";
            this.rdbIcon.UseVisualStyleBackColor = true;
            this.rdbIcon.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbFanyi
            // 
            this.rdbFanyi.AutoSize = true;
            this.rdbFanyi.Location = new System.Drawing.Point(436, 7);
            this.rdbFanyi.Name = "rdbFanyi";
            this.rdbFanyi.Size = new System.Drawing.Size(47, 16);
            this.rdbFanyi.TabIndex = 12;
            this.rdbFanyi.Text = "翻译";
            this.rdbFanyi.UseVisualStyleBackColor = true;
            this.rdbFanyi.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduApp
            // 
            this.rdbBaiduApp.AutoSize = true;
            this.rdbBaiduApp.Location = new System.Drawing.Point(340, 7);
            this.rdbBaiduApp.Name = "rdbBaiduApp";
            this.rdbBaiduApp.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduApp.TabIndex = 10;
            this.rdbBaiduApp.Text = "应用";
            this.rdbBaiduApp.UseVisualStyleBackColor = true;
            this.rdbBaiduApp.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduMap
            // 
            this.rdbBaiduMap.AutoSize = true;
            this.rdbBaiduMap.Location = new System.Drawing.Point(244, 7);
            this.rdbBaiduMap.Name = "rdbBaiduMap";
            this.rdbBaiduMap.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduMap.TabIndex = 8;
            this.rdbBaiduMap.Text = "地图";
            this.rdbBaiduMap.UseVisualStyleBackColor = true;
            this.rdbBaiduMap.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduMusic
            // 
            this.rdbBaiduMusic.AutoSize = true;
            this.rdbBaiduMusic.Location = new System.Drawing.Point(196, 7);
            this.rdbBaiduMusic.Name = "rdbBaiduMusic";
            this.rdbBaiduMusic.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduMusic.TabIndex = 7;
            this.rdbBaiduMusic.Text = "音乐";
            this.rdbBaiduMusic.UseVisualStyleBackColor = true;
            this.rdbBaiduMusic.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduBaike
            // 
            this.rdbBaiduBaike.AutoSize = true;
            this.rdbBaiduBaike.Location = new System.Drawing.Point(148, 7);
            this.rdbBaiduBaike.Name = "rdbBaiduBaike";
            this.rdbBaiduBaike.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduBaike.TabIndex = 6;
            this.rdbBaiduBaike.Text = "百科";
            this.rdbBaiduBaike.UseVisualStyleBackColor = true;
            this.rdbBaiduBaike.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduZhiDao
            // 
            this.rdbBaiduZhiDao.AutoSize = true;
            this.rdbBaiduZhiDao.Location = new System.Drawing.Point(100, 7);
            this.rdbBaiduZhiDao.Name = "rdbBaiduZhiDao";
            this.rdbBaiduZhiDao.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduZhiDao.TabIndex = 5;
            this.rdbBaiduZhiDao.Text = "知道";
            this.rdbBaiduZhiDao.UseVisualStyleBackColor = true;
            this.rdbBaiduZhiDao.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbBaiduWeb
            // 
            this.rdbBaiduWeb.AutoSize = true;
            this.rdbBaiduWeb.Location = new System.Drawing.Point(52, 7);
            this.rdbBaiduWeb.Name = "rdbBaiduWeb";
            this.rdbBaiduWeb.Size = new System.Drawing.Size(47, 16);
            this.rdbBaiduWeb.TabIndex = 4;
            this.rdbBaiduWeb.Text = "百度";
            this.rdbBaiduWeb.UseVisualStyleBackColor = true;
            this.rdbBaiduWeb.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbGoogleWeb
            // 
            this.rdbGoogleWeb.AutoSize = true;
            this.rdbGoogleWeb.Checked = true;
            this.rdbGoogleWeb.Location = new System.Drawing.Point(4, 7);
            this.rdbGoogleWeb.Name = "rdbGoogleWeb";
            this.rdbGoogleWeb.Size = new System.Drawing.Size(47, 16);
            this.rdbGoogleWeb.TabIndex = 3;
            this.rdbGoogleWeb.TabStop = true;
            this.rdbGoogleWeb.Text = "谷歌";
            this.rdbGoogleWeb.UseVisualStyleBackColor = true;
            this.rdbGoogleWeb.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // ckbShowSE
            // 
            this.ckbShowSE.AutoSize = true;
            this.ckbShowSE.BackColor = System.Drawing.Color.Transparent;
            this.ckbShowSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbShowSE.Font = new System.Drawing.Font("Arial", 5F);
            this.ckbShowSE.ForeColor = System.Drawing.Color.DarkOrange;
            this.ckbShowSE.Location = new System.Drawing.Point(4, 5);
            this.ckbShowSE.Name = "ckbShowSE";
            this.ckbShowSE.Size = new System.Drawing.Size(12, 11);
            this.ckbShowSE.TabIndex = 0;
            this.ckbShowSE.UseVisualStyleBackColor = false;
            this.ckbShowSE.CheckedChanged += new System.EventHandler(this.ckbShowSE_CheckedChanged);
            // 
            // ckbDock
            // 
            this.ckbDock.AutoSize = true;
            this.ckbDock.BackColor = System.Drawing.Color.Transparent;
            this.ckbDock.Checked = true;
            this.ckbDock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ckbDock.Font = new System.Drawing.Font("Arial", 5F);
            this.ckbDock.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.ckbDock.Location = new System.Drawing.Point(4, 21);
            this.ckbDock.Name = "ckbDock";
            this.ckbDock.Size = new System.Drawing.Size(12, 11);
            this.ckbDock.TabIndex = 0;
            this.ckbDock.UseVisualStyleBackColor = false;
            this.ckbDock.CheckedChanged += new System.EventHandler(this.ckbDock_CheckedChanged);
            // 
            // prbEyeGuardInterval
            // 
            this.prbEyeGuardInterval.Location = new System.Drawing.Point(548, 36);
            this.prbEyeGuardInterval.Name = "prbEyeGuardInterval";
            this.prbEyeGuardInterval.Size = new System.Drawing.Size(30, 2);
            this.prbEyeGuardInterval.TabIndex = 12;
            this.prbEyeGuardInterval.Visible = false;
            // 
            // ofdChangeIcon
            // 
            this.ofdChangeIcon.Filter = "PNG图标|*.png|ICON图标|*.ico|JPEG图标|*.jpeg|BMP图标|*.bmp";
            this.ofdChangeIcon.Title = "选择图片";
            // 
            // btnSearch
            // 
            this.btnSearch.ContextMenuStrip = this.cmsMain;
            this.btnSearch.Image = global::DeskTopOnline.Properties.Resources.zinnami_32;
            this.btnSearch.Location = new System.Drawing.Point(547, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(584, 66);
            this.Controls.Add(this.prbEyeGuardInterval);
            this.Controls.Add(this.ckbShowSE);
            this.Controls.Add(this.ckbDock);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.MainForm_MouseEnter);
            this.cmsMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NotifyIcon ntiMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDisplay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemQuit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbBaiduWenKu;
        private System.Windows.Forms.RadioButton rdbFanyi;
        private System.Windows.Forms.RadioButton rdbBaiduApp;
        private System.Windows.Forms.RadioButton rdbBaiduMap;
        private System.Windows.Forms.RadioButton rdbBaiduMusic;
        private System.Windows.Forms.RadioButton rdbBaiduBaike;
        private System.Windows.Forms.RadioButton rdbBaiduZhiDao;
        private System.Windows.Forms.RadioButton rdbBaiduWeb;
        private System.Windows.Forms.RadioButton rdbGoogleWeb;
        private System.Windows.Forms.RadioButton rdbIcon;
        private System.Windows.Forms.CheckBox ckbShowSE;
        private System.Windows.Forms.CheckBox ckbDock;
        private System.Windows.Forms.ProgressBar prbEyeGuardInterval;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemManage;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemShutDown;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemRestart;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemLogoff;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemHibernate;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemSleep;
        private System.Windows.Forms.ToolStripMenuItem tmiSoftWareSet;
        private System.Windows.Forms.ToolStripMenuItem tmiShortCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartUp;
        private System.Windows.Forms.ToolStripMenuItem tmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tmiSystemSet;
        private System.Windows.Forms.ToolStripMenuItem 功能组件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tmiCaptureScreen;
        private System.Windows.Forms.ToolStripMenuItem tmiEyeGuard;
        private System.Windows.Forms.OpenFileDialog ofdChangeIcon;
        private System.Windows.Forms.ToolStripMenuItem tmiAlarmClockSet;
        private System.Windows.Forms.ColorDialog cdgMainForm;
    }
}