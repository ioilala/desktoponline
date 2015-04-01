using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeskTopOnline
{
    public partial class FormPortraitGenerator : Form
    {
        #region 定义区域
        private Image m_GeneratedImg=null;
        /// <summary>
        /// 最终产生的图片
        /// </summary>
        public Image GeneratedImg
        {
            get { return m_GeneratedImg; }
        }
        private Bitmap bmpLoad = null;//加载的图片        
        private Bitmap bmp32 = null;
        private Bitmap bmp16 = null;
        private Rectangle recCutImg =new Rectangle();//绘制的矩形
        private Point recStartPoint;//矩形起始点
        private Point recEndPoint;//矩形终止点
        private bool flagStartDrawRec = false;//是否开始绘制矩形标识量
        private bool flagPicLoaded = false;//是否已经加载图片
        private SolidBrush sb;
        private Pen p;        
        public FormPortraitGenerator()
        {
            InitializeComponent();
            sb = new SolidBrush(Color.Black);
            p = new Pen(sb, 1);
        }
        #endregion
        #region 事件区域
        //选择图片
        private void btnChoosePic_Click(object sender, EventArgs e)
        {
            if (ofdChoosePic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    lbPicPath.Text = ofdChoosePic.FileName;
                    bmpLoad = new Bitmap(ofdChoosePic.FileName);
                    pbImgSrc.Image = bmpLoad;
                    flagPicLoaded = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"错误");                    
                }
            }
        }

        private void pbImgSrc_MouseDown(object sender, MouseEventArgs e)
        {
            if (flagPicLoaded)
            {
                flagStartDrawRec = true;
                recStartPoint = new Point(e.X, e.Y);
            }
        }

        private void pbImgSrc_MouseMove(object sender, MouseEventArgs e)
        {
            if (flagStartDrawRec)
            {
                if (Control.ModifierKeys == Keys.Shift)//画正方形
                {
                    int x = recStartPoint.X < e.X ? recStartPoint.X : e.X;
                    int y = recStartPoint.Y < e.Y ? recStartPoint.Y : e.Y;
                    int width = Math.Abs(e.X-recCutImg.X);
                    int height=Math.Abs(e.Y-recCutImg.Y);
                    int square = width > height ? height : width;
                    recCutImg = new Rectangle(new Point(x, y), new Size(square, square));
                    //recCutImg = new Rectangle(x, y, width, height);
                    //pbImgSrc.Invalidate();
                    pbImgSrc.Refresh();
                }
                else//画矩形
                {

                }
            }
        }

        private void pbImgSrc_MouseUp(object sender, MouseEventArgs e)
        {
            flagStartDrawRec = false;
            if (flagPicLoaded&&!recCutImg.IsEmpty)
            {
                //拷贝图像
                bmp32 = bmpLoad.Clone(recCutImg, bmpLoad.PixelFormat);
                pb32.Image = bmp32;
                pb32.Invalidate();
            }
        }
        private void pbImgSrc_Paint(object sender, PaintEventArgs e)
        {
            if (flagPicLoaded && flagStartDrawRec)
            {
                e.Graphics.DrawRectangle(p, recCutImg);
            }
        }
        //产生图片
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            this.m_GeneratedImg = pb32.Image;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        #endregion
        #region 释放区
        private void FormPortraitGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            sb.Dispose();
            p.Dispose();
        }
        #endregion

        

    }
}
