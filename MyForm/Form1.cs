using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IWshRuntimeLibrary;
using System.IO;
using System.Diagnostics;

namespace MyForm
{
    public partial class Form1 : Form
    {
        public static string  selfdesktopPath=Application.StartupPath + "\\desktop";
        DirectoryInfo selfdesktop = new DirectoryInfo(selfdesktopPath);
        string userdesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public Form1()
        {

            

            InitializeComponent();
       
            //this.BackColor = Color.FromArgb(30, 30, 30);
            //26,26,26 119, 136, 153  // 215,228,228 //26, 26, 26
            //76,76,79
            //45,46,48
            // 41,183,204
            int hieght = 30;
            int width = (this.panel1.Width - label1.Width - textBox1.Width - 40) / 7;
            appbt.Location = new Point(this.Location.X + this.Width - (width * 4) + 110, this.Location.Y);
            appbt.Height = hieght;
            appbt.Width = width;
            wordbt.Location = new Point(this.Location.X + this.Width - (width * 3) + 110, this.Location.Y);
            wordbt.Height = hieght;
            wordbt.Width = width;
            minboxbt.Location = new Point(this.Location.X + this.Width - (width * 2) + 110, this.Location.Y);
            minboxbt.Height = hieght;
            minboxbt.Width = width - 60;
            closebt.Location = new Point(this.Location.X + this.Width - (width * 1) + 50, this.Location.Y);
            closebt.Height = hieght;
            closebt.Width = width - 50;
            label1.Location = new Point(this.Location.X, this.Location.Y + (label1.Height / 2));
            label1.Height = hieght;
            textBox1.Location = new Point(this.Location.X + (label1.Width), this.Location.Y + (label1.Height / 3));
            textBox1.Height = hieght;
            panel1.Height = hieght;
            panel1.Width = this.Width;
            panel1.Location = new Point(this.Location.X, this.Location.Y + this.Height - panel1.Height);
            closebt.BringToFront();
          //  loaddesktop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(TakeFile.AppSetupPath);
            //if (TakeFile.CreateAppdeskTop())
            //{
            //    MessageBox.Show("ok");
            //}
            //else
            //{
            //    MessageBox.Show("no");
            //}
            //bool iscre = TakeFile.CreateAppdeskTop();
            //if (iscre)
            //{
            //    MessageBox.Show("应用桌面加载中");
            //}
            //else {

            //    MessageBox.Show("应用桌面加载erro");
            //}
            //bool isde = TakeFile.DeleteUserdesktop();
            //if (isde)
            //{
            //    MessageBox.Show("桌面优化中");
            //}
            //else
            //{
            //    MessageBox.Show("桌面优化erro");
            //}
            //bool iscreu = TakeFile.CreateUserdeskTop();
            //if (iscreu)
            //{ MessageBox.Show("桌面恢复成功！"); }
            //else
            //{
            //    MessageBox.Show("桌面恢复erro");
            //}

            //     MessageBox.Show(GetDesktop.GetAllUsersDesktopFolderPath());

            loaddesktop();


        }


        private void loaddesktop()

        {
          

            if (!selfdesktop.Exists)
            {
                selfdesktop.Create();
            }
            else
            {
                
           

                // Console.WriteLine("该目录已经存在");
           
            Panel panel = new System.Windows.Forms.Panel();
            panel.Location = new System.Drawing.Point(this.Location.X, this.Location.Y+20);
            panel.AutoScroll = true;
          //  panel.BackColor = Color.Red;
            panel.Size = new System.Drawing.Size(this.Width,this.Height-panel1.Height-20);
            string dir = GetAllUsersDesktopFolderPath(); // Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DirectoryInfo dirinfo = new DirectoryInfo(dir);
            DirectoryInfo dirinfo1 = new DirectoryInfo(dir1);
            int couunt = 1;
           // 遍历文件夹
            foreach (DirectoryInfo NextFolder in dirinfo.GetDirectories())
            {
                //  this.listBox1.Items.Add("文件夹:" + NextFolder.Name);

            }

                //遍历文件
              foreach (FileInfo NextFile in dirinfo.GetFiles())
                {

                    if (NextFile.Name.ToString().Contains(".ini"))
                    { }
                    else
                    {
                        Button bt1 = new System.Windows.Forms.Button();

                        bt1.Location = new System.Drawing.Point((couunt - 1) * 75, 0);
                        bt1.Name = getappexepath(NextFile.FullName);
                        bt1.Size = new System.Drawing.Size(55, 55);
                        bt1.TabIndex = 2;
                        Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(bt1.Name);
                        Bitmap b = icon.ToBitmap();
                        Image img = b;
                        bt1.Image = img;
                        bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        bt1.FlatAppearance.BorderSize = 0;
                        bt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                        bt1.Text = "-";
                        bt1.UseVisualStyleBackColor = true;
                        bt1.Click += new EventHandler(bt1_Click);
                        couunt++;
                        panel.Controls.Add(bt1);

                        try
                        {
                            if (System.IO.File.Exists(NextFile.FullName))
                            {
                                System.IO.File.Copy(NextFile.FullName, selfdesktopPath + "\\" + NextFile.Name, true);
                                System.IO.File.Delete(NextFile.FullName);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }


                    }
                }
            //遍历文件夹
            foreach (DirectoryInfo NextFolder in dirinfo1.GetDirectories())
            {
                // NextFolder.Name;
            }

            //遍历文件
            foreach (FileInfo NextFile in dirinfo1.GetFiles())
            {
                   
                if (NextFile.Name.ToString().Contains(".ini"))
                { }
                else
                {

                    Button bt1 = new System.Windows.Forms.Button();

                    bt1.Location = new System.Drawing.Point((couunt - 1) * 75, 0);
                    bt1.Name = getappexepath(NextFile.FullName);
                    bt1.Size = new System.Drawing.Size(55, 55);
                    bt1.TabIndex = 2;
                    Icon icon = null;
                    Image img = null;
                    try
                    {
                        icon = System.Drawing.Icon.ExtractAssociatedIcon(bt1.Name.ToString().Trim());
                        Bitmap b = icon.ToBitmap();
                         img = b;
                    }
                    catch (Exception)
                    {
                        
                       // throw;
                    }
                 
                    bt1.Image = img;
                    bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    bt1.FlatAppearance.BorderSize = 0;
                    bt1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    bt1.Text ="-";
                    bt1.UseVisualStyleBackColor = true;
                    bt1.Click += new EventHandler(bt1_Click);
                    couunt++;
                    panel.Controls.Add(bt1);

                      

                        try
                        {
                            if (System.IO.File.Exists(NextFile.FullName))
                            {
                                System.IO.File.Copy(NextFile.FullName, selfdesktopPath + "\\" + NextFile.Name, true);
                                System.IO.File.Delete(NextFile.FullName);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }


                    }



                }

             
                 
               








                    panel.Visible = true;
                   this.Controls.Add(panel);
            }

        }


        protected void bt1_Click(object sender, EventArgs e)
        {
            // 事件处理程序
            Button bt = (Button)sender;
            string Path = bt.Name.ToString();
            Process.Start(Path);
            MessageBox.Show(String.Format("外部程序 {0} 启动完成！", bt.Text), this.Text,
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        }









        // 用于窗口移动

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]

        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);

        }



        //用于得到用户桌面文件夹

        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);
        private const int MAX_PATH = 260;
        private const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x0019;         
        public static string GetAllUsersDesktopFolderPath()
        {
            StringBuilder sbPath = new StringBuilder(MAX_PATH);
            SHGetFolderPath(IntPtr.Zero, CSIDL_COMMON_DESKTOPDIRECTORY, IntPtr.Zero, 0, sbPath);
            return sbPath.ToString();
        }

        
        public string getappexepath(string path)
        {
            

            string path1 = "";

            try
            {
                IWshShortcut _shortcut = null;
                IWshShell_Class shell = new IWshShell_Class();
                if (System.IO.File.Exists(path) == true)
                    _shortcut = shell.CreateShortcut(path) as IWshShortcut;//在vs2010中CreateShortcut返回dynamic 类型

                //所以要加as 进行对象类型转换       
                path1 = _shortcut.TargetPath;
            }
            catch
            {

            }

            return path1;

        }

        private void closebt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (selfdesktop.Exists)
            {
                foreach (FileInfo link in selfdesktop.GetFiles())
                {
                    if (!System.IO.File.Exists(userdesktop + "\\" + link.Name))
                        System.IO.File.Copy(link.FullName, userdesktop + "\\" + link.Name);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Form1_FormClosed(null, null);
            }
            catch (Exception)
            {

               // throw;
            }
           
        }
    }
}
