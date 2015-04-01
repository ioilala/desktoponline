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
    public partial class FormRestScreen : Form
    {
        private int m_totalRestTime = 0;
        private System.Timers.Timer tmTick = new System.Timers.Timer();
        /// <summary>
        /// 总休息时间(min)
        /// </summary>
        public int TotalRestTime
        {
            get { return m_totalRestTime; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("总休息时间不能为负值");
                }
                m_totalRestTime = value*60;
                prbTime.Maximum = value*60;
            }
        }

        public FormRestScreen()
        {
            InitializeComponent();
            tmTick.Interval = 1000;//每s更新下进度
            tmTick.Elapsed += new System.Timers.ElapsedEventHandler(tmTick_Elapsed);
        }

        //每s更新下界面
        private void tmTick_Elapsed(object sender, ElapsedEventArgs e)
        {
            m_totalRestTime--;
            prbTime.Value = m_totalRestTime;
            if (m_totalRestTime == 0)
            {
                this.Visible = false;
            }
        }
        
        private void FormRest_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(0,0);
            //this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            prbTime.Value = m_totalRestTime;
            tmTick.Start();
        }
        //按键起来
        private void FormRest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt)
            {
                switch (e.KeyCode)
                { 
                    case Keys.Escape:
                        if (TotalRestTime - m_totalRestTime > 60)//1min后可解锁
                        {
                            this.Close();
                        }
                        break;
                }
            }
        }
    }
}
