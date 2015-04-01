using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace DeskTopOnline
{
    public class FormEffect
    {
        //闪烁
        public static void Blink(Form fm)
        {
            fm.Visible = false;
            Thread.Sleep(500);
            fm.Visible = true;
            Thread.Sleep(500);
        }
        //
        public static void Swift(Form fm)
        {
            int x=fm.Location.X;
            int y=fm.Location.Y;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    fm.Location = new Point(x + i, y);
                    Thread.Sleep(30);
                }
                for (int i = 0; i < 5; i++)
                {
                    fm.Location = new Point(x - i, y);
                    Thread.Sleep(5);
                }
            }
        }
    }
}
