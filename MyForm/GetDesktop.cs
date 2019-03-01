using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace MyForm
{
    public class GetDesktop
    {



        /// <summary>
        /// 当前用户的桌面文件夹路径
        /// </summary>
        public static string DesktopNowUserFlolderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);


        public GetDesktop()
        {
            SetDeskTopDictionary();
            SetDeskTopImgDictionary();
            SetIdexepathDictionary();
        }

        /// <summary>
        /// 所有用户桌面目录的directory
        /// </summary>
        public static  DirectoryInfo DeskTopAlluserdir = new DirectoryInfo(GetAllUsersDesktopFolderPath());
        /// <summary>
        ///当前用户桌面目录的directory
        /// </summary>
        public static DirectoryInfo DeskTopNowuserdir = new DirectoryInfo(GetNowuserDesktopFolderPath());

        /// <summary>
        /// 所有桌面的文件字典
        /// </summary>
        private Dictionary<string, string[]> AllDeskTopDictionary = new Dictionary<string, string[]>();

        private Dictionary<string, string[]> AllDeskTopDictionary1
        {
            get { return AllDeskTopDictionary; }
            set { AllDeskTopDictionary = value; }
        }
         /// <summary>
        /// 所有桌面的文件图标字典
        /// </summary>
        private Dictionary<string, Image> AllDeskTopImgDictionary = new Dictionary<string, Image>();

public Dictionary<string, Image> AllDeskTopImgDictionary1
{
  get { return AllDeskTopImgDictionary; }
  set { AllDeskTopImgDictionary = value; }
}

        public static Dictionary<int, string> ExeidPathdic = new Dictionary<int, string>();

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        private const int MAX_PATH = 260;
        private const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019;


        /// <summary>
        /// 得到当前主机所有用户桌面目录
        /// </summary>
        /// <returns>所有用户桌面目录Path</returns>
        public static string GetAllUsersDesktopFolderPath()
        {
            try
            {
                StringBuilder sbPath = new StringBuilder(MAX_PATH);
                SHGetFolderPath(IntPtr.Zero, CSIDL_COMMON_DESKTOPDIRECTORY, IntPtr.Zero, 0, sbPath);
                return sbPath.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string GetNowuserDesktopFolderPath()
        {
            return DesktopNowUserFlolderPath;

        }




        public Dictionary<string,string[]> getdesktopdic()
        {
            return AllDeskTopDictionary;
        }

        public Dictionary<string, Image> getdesktopdicimg()
        {
            return AllDeskTopImgDictionary;
        }
      /// <summary>
      /// 设置桌面字典
      /// </summary>
      private void SetDeskTopDictionary()
        {
            Dictionary<string, string[]> alluser = DirectoryInfoScanners(DeskTopAlluserdir);
            Dictionary<string, string[]> nowuser = DirectoryInfoScanners(DeskTopNowuserdir);
            AllDeskTopDictionary = Dicand(alluser, nowuser);
        }

      private void SetDeskTopImgDictionary()
      {
          AllDeskTopImgDictionary.Clear();
      foreach (string str in   AllDeskTopDictionary.Keys )
      {
          try
          {
               Image img=null;
              if(AllDeskTopDictionary[str][1]=="F")
              {
              img=GetDirImg();
              }
              else
              {
              img=GetFileImg(AllDeskTopDictionary[str][2]);
              }
            
              AllDeskTopImgDictionary.Add(str,img);
          }
          catch (Exception)
          {
              
              throw;
          }
      
      }
     
      
      }

        private void SetIdexepathDictionary()
        {
            foreach (string s in AllDeskTopDictionary.Keys)
            {
                try
                {
                    ExeidPathdic.Add(Convert.ToInt32(AllDeskTopDictionary[s][3]), AllDeskTopDictionary[s][2]);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
        /// <summary>
        ///  执行exe文件
        /// </summary>
        /// <param name="Path">执行路径</param>
        public static void SetupExe(string Path)
        {
            try
            {
                Process.Start(Path);
            }
            catch (Exception)
            {

                MessageBox.Show("未知启动，无法打开！");
            }
           
            //MessageBox.Show(String.Format("外部程序 {0} 启动完成！", bt.Text), this.Text,
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 执行exe文件
        /// </summary>
        /// <param name="Path">执行路径</param>
        public static void SetupExplorer(string Path)
        {
            try
            {
                Process.Start("Explorer.exe", Path);
            }
            catch (Exception)
            {

                MessageBox.Show("文件不存在，无法打开！");
            }
       
            //MessageBox.Show(String.Format("外部程序 {0} 启动完成！", bt.Text), this.Text,
            //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 根据lnk path得到用户的exe 执行路径
        /// </summary>
        /// <param name="path">快捷方式lnk path</param>
        /// <returns>执行路径</returns>
        /// 

        public static string GetAppExePath(string path)
        {


            string exepath = "";

            try
            {
                IWshShortcut _shortcut = null;
                IWshShell_Class shell = new IWshShell_Class();
                if (System.IO.File.Exists(path) == true)
                    _shortcut = shell.CreateShortcut(path) as IWshShortcut;//在vs2010中CreateShortcut返回dynamic 类型

                //所以要加as 进行对象类型转换       
               exepath = _shortcut.TargetPath;
            }
            catch
            {
               
            }

            return exepath;

        }


        public string getexepathForid(int id)
        {
            return ExeidPathdic[id];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"> 扫描directoryinfo</param>
        /// <returns>返回dictionaty<string，string[]>,string[0] 路径，string[1]类型，ps:文件夹 ，string[2]执行路径,string[3]id</returns>
        public static Dictionary<string, string[]> DirectoryInfoScanners(DirectoryInfo dir)
        {
            int id = 0;
            Dictionary<string, string[]> dic = new Dictionary<string, string[]>();
            dic.Clear();
           
            foreach (DirectoryInfo dirinfo in dir.GetDirectories())
            {
                string[] txt = new string[]{dirinfo.FullName,"F",dirinfo.FullName.Replace(GetAllUsersDesktopFolderPath(),TakeFile.AppDeskTopPath).Replace(DesktopNowUserFlolderPath,TakeFile.AppDeskTopPath).Replace(@"\\",@"\") ,id.ToString() };
                dic.Add(dirinfo.Name, txt);

                id++;
            }
            foreach (FileInfo file in dir.GetFiles())
            {
                if (!file.Name.Contains("ini"))
                { 
                    string[] txt = new string[] { file.FullName, file.Extension.ToString(),null,id.ToString() };


                if (file.Extension.ToString().Contains("lnk"))
                {
                    txt[2] = GetAppExePath(txt[0]);
                }
                else
                {
                        txt[2] = file.FullName.Replace(GetAllUsersDesktopFolderPath(), TakeFile.AppDeskTopPath).Replace(DesktopNowUserFlolderPath, TakeFile.AppDeskTopPath).Replace(@"\\", @"\");
                }


                dic.Add(file.Name, txt);
                id++;
                }
            }
            return dic;
        }

       
      /// <summary>
      /// 字典相加
      /// </summary>
      /// <param name="sourcedictionary">源字典</param>
      /// <param name="tergetdictionary">目标字典</param>
      /// <returns></returns>
      public static Dictionary<string,string[]> Dicand(Dictionary<string,string[]>  sourcedictionary,Dictionary <string,string[]>tergetdictionary)
        {
            foreach (string s in tergetdictionary.Keys)
            {

                if (!sourcedictionary.ContainsKey(s))
                {
                    sourcedictionary.Add(s,tergetdictionary[s]);
                }
               
            }
            return sourcedictionary;
        }
        public static Dictionary<string, string[]> Dicand(Dictionary<string, string[]> sourcedictionary, Dictionary<string, string[]> tergetdictionary,bool ischange)
        {
            foreach (string s in tergetdictionary.Keys)
            {

                if (!sourcedictionary.ContainsKey(s))
                {
                    sourcedictionary.Add(s, tergetdictionary[s]);
                }
                else
                {
                    if (ischange == true)
                    {

                        sourcedictionary[s] = tergetdictionary[s];
                    }
                }

            }
            return sourcedictionary;
        }


       


        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        /// <summary>  
        /// 返回系统设置的图标  
        /// </summary>  
        /// <param name="pszPath">文件路径 如果为""  返回文件夹的</param>  
        /// <param name="dwFileAttributes">0</param>  
        /// <param name="psfi">结构体</param>  
        /// <param name="cbSizeFileInfo">结构体大小</param>  
        /// <param name="uFlags">枚举类型</param>  
        /// <returns>-1失败</returns>  
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public enum SHGFI
        {
            SHGFI_ICON = 0x100,
            SHGFI_LARGEICON = 0x0,
            SHGFI_USEFILEATTRIBUTES = 0x10
        }


        /// <summary>  
        /// 获取文件图标 zgke@sina.com qq:116149  
        /// </summary>  
        /// <param name="p_Path">文件全路径</param>  
        /// <returns>图标</returns>  
        public static Icon GetFileIcon(string p_Path)
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            IntPtr _IconIntPtr = SHGetFileInfo(p_Path, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_USEFILEATTRIBUTES));
            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }
        /// <summary>  
        /// 获取文件夹图标  zgke@sina.com qq:116149  
        /// </summary>  
        /// <returns>图标</returns>  
        public static Icon GetDirectoryIcon()
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            IntPtr _IconIntPtr = SHGetFileInfo(@"", 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON));
            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }
        public static Image GetFileImg(string path)
        {
            Icon ic = GetFileIcon(path);
            Image img =ic.ToBitmap();
            return img;
        }
        public static Image GetDirImg()
        {
            Icon ic = GetDirectoryIcon();
            Image img = ic.ToBitmap();
            return img;
        }

        public static Image GetExeImg(string path)
        {
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
            Bitmap b = icon.ToBitmap();
            Image img = b;
            return b;
        }
        public static Image GetLnkImg(string path)
        {
            path = GetAppExePath(path);
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
            Bitmap b = icon.ToBitmap();
            Image img = b;
            return b;
        }

    }
}
