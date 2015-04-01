using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;
using System.Runtime.InteropServices;

namespace DeskTopOnline
{
    public class FuncLib
    {
        #region 拖动窗体
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;
        #endregion
        //开始拖动窗体
        public static void StartDrag(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //创建快捷方式
        public static bool CreateDesktopLnk(string lnkstr)
        {
            try
            {
                Shortcut sc = new Shortcut();
                sc.Path = Application.ExecutablePath;
                sc.Arguments = "";
                sc.WorkingDirectory = Application.StartupPath + "\\";
                sc.Description = lnkstr;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + lnkstr + ".lnk";
                sc.Save(path);
                sc = null;
                return true;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message, "创建快捷方式");
                return false;
            }
        }
        //智能化检查是否已经设置启动项,返回true表示本次更新或者重设了开机启动项
        public static bool CheckStartUPSet()
        {
            RegistryKey key=null;
            try
            {
                //string exeName = Process.GetCurrentProcess().ProcessName;
                string exeName = "DeskTopOnline";
                string path = Application.ExecutablePath;
                key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run",true);
                if (CheckSubKeyExist(key, exeName))//存在本项
                {
                    if (Convert.ToString(key.GetValue(exeName)) != path)//路径不一致
                    {
                        if (MessageBox.Show("本软件已在其他路径设为启动项，是否更新本次路径为启动项?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //更新值
                            key.SetValue(exeName, path);//将新路径设置为开机启动
                            key.Close();
                            return true;
                        }
                    }
                }
                else//不存在本项
                {
                    if (MessageBox.Show("是否设置本软件开机启动？你也可以稍后在设置菜单中设置", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SetStartUp(true, exeName);
                        return true;
                    }
                }
                key.Close();
                return false;
            }
            catch(Exception ex)
            {
                key.Close();
                return false;
            }
        }
        //确定注册表中某一个节点是否存在某一项
        public static bool CheckSubKeyExist(RegistryKey key,string subname)
        {
            string[] subkeyNames = key.GetValueNames();
            bool flag=false;
            foreach(string keyname in subkeyNames)
            {
                if (keyname == subname)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        //设置/取消开机启动
        public static bool SetStartUp(bool started, string exeName)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);//打开注册表子项
                string path = Application.ExecutablePath;
                if (key == null)//如果该项不存在的话，则创建该子项
                {
                    key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                if (started == true)
                {
                    key.SetValue(exeName, path);//设置为开机启动
                    key.Close();
                }
                else
                {
                    key.DeleteValue(exeName, false);//取消开机启动
                    key.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "开机启动");
                return false;
            }
        }
        //单例模式运行软件
        public static void CheckSingleThread()
        {
            int num = 0;
            string prostr = Process.GetCurrentProcess().ProcessName;
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (prostr == pr.ProcessName)
                {
                    num++;
                }
            }
            if (num > 1)
            {
                MessageBox.Show("本软件已经在运行，请勿重复运行!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }
        }
        //判断是否为URL
        public static bool IsURL(string url)
        {
            return Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }
        //字符串转UTF8
        public static string StrToUtf8(string str)
        {
            str = str.Trim(' ');
            Encoding eUtf8 = Encoding.UTF8;
            str = HttpUtility.UrlEncode(str, eUtf8);
            return str;
        }
        //字符串转Gb2312
        public static string StrToGb2312(string str)
        {
            str = str.Trim(' ');
            Encoding egb2312 = Encoding.GetEncoding("gb2312");
            str = HttpUtility.UrlEncode(str, egb2312);
            return str;
        }
    }
}
