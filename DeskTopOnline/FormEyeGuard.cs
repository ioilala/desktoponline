using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Timers;
namespace DeskTopOnline
{
    public delegate void HandleEyeGuard(int n);
    public partial class FormEyeGuard :Form
    {
        #region 类定义区
        public static event HandleEyeGuard EventEyeGuard=null;
        private System.Timers.Timer tmRestInterval = new System.Timers.Timer();
        private FormRestScreen fmRest = new FormRestScreen();
        public bool flagEyeGuard = false;//是否在护眼模式
        public int nRestInterval = 600;//休息间隔，s为单位
        public int nRestTime = 10;//休息时长，min为单位
        #endregion
        #region 类初始化
        //构造函数
        public FormEyeGuard()
        {
            InitializeComponent();
            tmRestInterval.Elapsed+=new System.Timers.ElapsedEventHandler(tmRest_Elapsed);
        }
        #endregion
        #region 类事件区         
        //启动休息
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            nRestInterval = Convert.ToInt32(nudRestInterval.Value)*60;
            tmRestInterval.Interval = 1000;
            tmRestInterval.Start();
            this.Visible = false;
        }
        //停止休息
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            tmRestInterval.Stop();
            this.Visible = true;
        }
        //休息间隔
        private void tmRest_Elapsed(object sender, ElapsedEventArgs e)
        {
            nRestInterval--;
            if (EventEyeGuard != null)
            {
                EventEyeGuard(nRestInterval);
            }
            if (nRestInterval == 0)//时间到
            {
                tmRestInterval.Stop();
                nRestInterval = Convert.ToInt32(nudRestInterval.Value);
                nRestTime = Convert.ToInt32(nudRestTime.Value);
                fmRest.TotalRestTime = nRestTime;
                //fmRest.BringToFront();
                //fmRest.Focus();
                fmRest.ShowDialog();
                tmRestInterval.Start();
            }
        }
        #endregion
        
        private void EyeGuard_Load(object sender, EventArgs e)
        {
            if (flagEyeGuard)
            {
                btnStart.Enabled = false;
            }
            else
            {
                btnStart.Enabled = true;
            }
        }
        #region 类功能区
        public void StopEyeGuard()
        {
            flagEyeGuard = false;
            tmRestInterval.Stop();
        }
        #endregion
    }
}
