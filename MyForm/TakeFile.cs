using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;

namespace MyForm
{
    class TakeFile
    {
        public static string DesktopNowUserFlolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string DesktopAllUserFlolderPath = GetDesktop.GetAllUsersDesktopFolderPath();
        public static string AppSetupPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        public static string AppDeskTopPath = AppSetupPath + "desktop\\";
        public static string AppDeskTopPath2 = AppSetupPath + "desktop2";
        public static string AppDeletedir = AppSetupPath + "delete";

        private void  bt_click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            Form f =(Form)bt.Parent;
            f.Visible = false;
        }
        public TakeFile()
        {
            Form f = new Form();
            f.StartPosition=System.Windows.Forms.FormStartPosition.CenterScreen;
            Button bt = new Button();
            bt.Text = "好的";
            bt.Click += new EventHandler(bt_click);
            

            f.Controls.Add(bt);
            
            if (CreateAppdeskTop())
            {
                f.Size = new System.Drawing.Size(500,100);
                f.Text = "应用桌面初始化,请稍等...";
                f.ShowDialog();
                f.Visible = false;
                if (DeleteUserdesktop())
                {
               
                    f.Visible = true;
                    f.Text = "应用初始化完成！欢迎使用 Flat Deak Top!";
                    Thread.Sleep(1000);
                }
            }
            else
            {
                f.Visible = false;
                f.Text="应用桌面初始化失败,正在处理请稍等...";
                f.Visible = true;
                int cout = 0;
                for (; CreateAppdeskTop();)
                {

                    if (cout>=5)
                    {
                        MessageBox.Show("应用桌面初始化失败,程序退出！");
                        Application.Exit();
                    }
                    cout++;
                }
               
            }

            f.Close();
        }
       public static bool CreateAppdeskTop()
        {
            bool iscopyall = false;
            bool iscopynow = false;
            bool iscopy = false;

            DirectoryInfo appdesktopfloder = new DirectoryInfo( AppDeskTopPath);
            if (appdesktopfloder.Exists)
            {
                Directory.Delete(AppDeskTopPath,true);
                appdesktopfloder.Create();
                iscopyall = CopyOldLabFilesToNewLab(GetDesktop.GetAllUsersDesktopFolderPath(), AppDeskTopPath);
                iscopynow = CopyOldLabFilesToNewLab(DesktopNowUserFlolderPath, AppDeskTopPath);
                iscopy = CopyOldLabFilesToNewLab(AppDeskTopPath, AppDeskTopPath2);
            }
            else
            {
              appdesktopfloder.Create();
                iscopynow = CopyOldLabFilesToNewLab(DesktopNowUserFlolderPath, AppDeskTopPath);
                iscopyall = CopyOldLabFilesToNewLab(GetDesktop.GetAllUsersDesktopFolderPath(), AppDeskTopPath);
                iscopy = CopyOldLabFilesToNewLab(AppDeskTopPath, AppDeskTopPath2);
            }

            return iscopynow&&iscopyall&&iscopy;



        }
       public static bool CreateUserdeskTop()
        {
            try
            {
                if (Directory.GetFiles(AppDeskTopPath).Length>3)
                {
                    CopyOldLabFilesToNewLab(AppDeskTopPath, DesktopNowUserFlolderPath);
                }
                else
                {
                    CopyOldLabFilesToNewLab(AppDeskTopPath2, DesktopNowUserFlolderPath);
                   

                }
            }
            catch (Exception)
            {
                CopyOldLabFilesToNewLab(AppDeskTopPath2, DesktopAllUserFlolderPath);
                MessageBox.Show("恢复桌面异常，正在从备份桌面恢复...");
                return false;
            }     
            
            return true;
           
        }
       public  bool CreateUserdeskTops()
        {
            try
            {
                CopyOldLabFilesToNewLab(AppDeskTopPath, DesktopNowUserFlolderPath);
            }
            catch (Exception)
            {
                CopyOldLabFilesToNewLab(AppDeskTopPath2, DesktopAllUserFlolderPath);
                MessageBox.Show("恢复桌面异常，正在从备份桌面恢复...");
                return false;
            }

            return true;

        }


        public static bool DeleteUserdesktop()
        {
            DirectoryInfo nowtop = new DirectoryInfo(DesktopNowUserFlolderPath);
            DirectoryInfo alltop = new DirectoryInfo(DesktopAllUserFlolderPath);
            
            try
            {
              
                return DirDlete(nowtop) && DirDlete(alltop);

            }
            catch (Exception)
            {
               // return false;
                throw;
                
            }

            
            





        }


        public static bool DirDlete(DirectoryInfo dir)
        {
            if (!Directory.Exists(AppDeletedir))
            {
                Directory.CreateDirectory(AppDeletedir);

            }

            if (dir.Exists)
            {

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    if (di.Exists)
                    {
                       
                        try
                        {
                            CopyOldLabFilesToNewLab(di.FullName, AppDeletedir + "\\" + di.Name);
                            Directory.Delete(di.FullName, true);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("桌面文件夹正在被其他程序占用,桌面初始化失败！建议关闭打开文件");
                            return false;
                        }

                    }
                    continue;
                }
                foreach (FileInfo fi in dir.GetFiles())
                {
                    if (fi.Exists)
                    {
                        
                        try
                        {
                            File.Copy(fi.FullName, AppDeletedir + "\\" + fi.Name, true);
                            File.Delete(fi.FullName);
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("桌面文件正在被其他程序占用,桌面初始化失败！建议关闭打开程序");
                            throw;
                            return false;
                        }

                    }
                    continue;
                }

                return true;

            }
            else
            {
                return false;
            }



            
            }

        /// <summary>
        /// 拷贝oldlab的文件到newlab下面
        /// </summary>
        /// <param name="sourcePath">lab文件所在目录(@"~\labs\oldlab")</param>
        /// <param name="savePath">保存的目标目录(@"~\labs\newlab")</param>
        /// <returns>返回:true-拷贝成功;false:拷贝失败</returns>
        public static bool CopyOldLabFilesToNewLab(string sourcePath, string savePath)
        {
            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            #region //拷贝labs文件夹到savePath下
            try
            {
                string[] labDirs = Directory.GetDirectories(sourcePath);//目录
                string[] labFiles = Directory.GetFiles(sourcePath);//文件
                if (labFiles.Length > 0)
                {
                    for (int i = 0; i < labFiles.Length; i++)
                    {
                        if (Path.GetFileName(labFiles[i]) != ".lab")//排除.lab文件
                        {
                            File.Copy(sourcePath + "\\" + Path.GetFileName(labFiles[i]), savePath + "\\" + Path.GetFileName(labFiles[i]), true);
                        }
                    }
                }
                if (labDirs.Length > 0)
                {
                    for (int j = 0; j < labDirs.Length; j++)
                    {
                        Directory.GetDirectories(sourcePath + "\\" + Path.GetFileName(labDirs[j]));

                        //递归调用
                        CopyOldLabFilesToNewLab(sourcePath + "\\" + Path.GetFileName(labDirs[j]), savePath + "\\" + Path.GetFileName(labDirs[j]));
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            #endregion
            return true;
        }


      





        #region 将程序添加到启动项
        /// <summary>
        /// 注册表操作，将程序添加到启动项
        /// </summary>
        public static void SetRegistryApp()
        {
            try
            {
                Microsoft.Win32.RegistryKey Reg;
                string ShortFileName = Application.ProductName;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.SetValue(ShortFileName, Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 将程序从启动项中删除
        /// <summary>
        /// 注册表操作，删除注册表中启动项
        /// </summary>
        public static bool DeleteRegisterApp()
        {
            string ShortFileName = Application.ProductName;           //获得应用程序名

            try
            {
                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }
                Reg.DeleteValue(ShortFileName, false);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        ///     检查当前程序是否在启动项中
        /// </summary>
        /// <returns></returns>
        public static bool CheckExistRegisterApp()
        {
            string ShortFileName = Application.ProductName;           //获得应用程序名
            bool bResult = false;

            try
            {
                Microsoft.Win32.RegistryKey Reg;
                Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (Reg == null)
                {
                    Reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                }

                foreach (string s in Reg.GetValueNames())
                {
                    if (s.Equals(ShortFileName))
                    {
                        bResult = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return bResult;
        }














    }
}
