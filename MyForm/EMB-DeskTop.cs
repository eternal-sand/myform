using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyForm
{
    public partial class EMB_DeskTop : Form
    {
        TakeFile initial = null;
        GetDesktop desktop = null;
        Dictionary<string, string[]> topdictionary = null;
        Dictionary<string, Image> topimg = null;
        public EMB_DeskTop()
        {
           
            InitializeComponent();
           // Form_initialize();

        }

        private void EMB_DeskTop_Load(object sender, EventArgs e)
        {
          
            //desktop = new GetDesktop();
            //topdictionary = desktop.getdesktopdic();
            //topimg = desktop.getdesktopdicimg();
            //initial = new TakeFile();
            //loadtExeBoutton();
        }

        //private void  Form_initialize()
        //   {

        //    closebttoolTip.SetToolTip(close_bt,"退出");
        //    this.Text = "Thanks Used EMB-DeskTop";
        //    this.MinimizeBox = false;
        //    this.MaximizeBox = false;
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        //    this.ShowInTaskbar = false;
        //    this.DoubleBuffered = true;
        //    this.Opacity = 0.85D;
        //    this.BackColor = Color.FromArgb(45, 46, 48);
        //    this.StartPosition = FormStartPosition.Manual;
        //    this.Size = new Size( Convert.ToInt32( Seting.ScreemWidth*0.73), Convert.ToInt32(Seting.ScreemHeight*0.17));
        //    this.Location = new Point((Seting.ScreemWidth - this.Width)/2+20,Convert.ToInt32((Seting.ScreemHeight*0.95))-this.Height);
        //    // Seting.FormSlowLightingout(this);
        //    // Seting.Formtopout(this);
        //    Seting.Formleftgout(this);
        //    // Seting.Formbouttomout(this);
        //    // Panel panel_under = new Panel();
        //    int formboder = Convert.ToInt32(this.Width * 0.02);
        //    panel_under.Width = this.Width-( formboder*2 )  ;
        //    panel_under.Height =Convert.ToInt32( this.Height/4);
        //    int btheight = panel_under.Height;
        //    panel_under.BackColor= Color.FromArgb(76, 76, 79);
        //    panel_under.Name = "panel_under";
        //    panel_under.Top = (this.Height - panel_under.Height)-(formboder/4);
        //    panel_under.Left =Math.Abs( close_bt.Width-formboder);
        //    int splspace = Convert.ToInt32(panel_under.Height * 0.1);
        //    splitContainer1.Height = panel_under.Height- (splspace * 2);
        //    splitContainer2.Height = panel_under.Height-(splspace * 2);
        //    splitContainer1.Width = panel_under.Width-(splspace*4);
        //    splitContainer2.Width = panel_under.Width-(splspace*4);
        //    int btspace = Convert.ToInt32(splitContainer1.Height*0.6);
        //    splitContainer1.SplitterDistance = splitContainer1.Width -(btheight * 2)-5;
        //    splitContainer2.SplitterDistance= splitContainer1.SplitterDistance-((btheight * 2) + (btspace * 2) + 180);
        //    splitContainer1.Left = (splspace*2);
        //    splitContainer1.Top = splspace;
        //    splitContainer2.Left = (splspace * 2);
        //    splitContainer2.Top = splspace;
        //    int txtspace = Convert.ToInt32(splitContainer1.Height * 0.2);
        //    abt.Height = splitContainer1.Height-txtspace;
        //    abt.Width = abt.Height;
        //    abt.Left = 0;
        //    abt.Top = txtspace;
        //    search_txt.Height = splitContainer1.Height-txtspace;
        //    search_txt.Width = 180;
        //    search_txt.Left = abt.Width;
        //    search_txt.Top =txtspace ;
        //    search_bt.Height = splitContainer1.Height-txtspace;
        //    search_bt.Width = search_bt.Height;
        //    search_bt.Left = abt.Width + search_txt.Width;
        //    search_bt.Top = txtspace;
        //    applacation_bt.Top = 0;
        //    applacation_bt.Left =(btspace*1)+ 0;
        //    applacation_bt.Height = splitContainer1.Height;
        //    applacation_bt.Width = applacation_bt.Height;
        //    file_bt.Top = 0;
        //    file_bt.Left = (btspace * 2) + applacation_bt.Width+btspace;
        //    file_bt.Height = splitContainer1.Height;
        //    file_bt.Width = file_bt.Height;
        //    help_bt.Top = txtspace/2;
        //    help_bt.Left =0;
        //    help_bt.Height = splitContainer1.Height-txtspace;
        //    help_bt.Width = help_bt.Height;
        //    minbox_bt.Top = txtspace/2;
        //    minbox_bt.Left = help_bt.Width + btspace;
        //    minbox_bt.Height = splitContainer1.Height-txtspace;
        //    minbox_bt.Width = minbox_bt.Height;
           
        //    close_bt.Height = splitContainer1.Height;
        //    close_bt.Width = close_bt.Height;
        //    close_bt.Top = this.Height-close_bt.Height;
        //    close_bt.Left = this.Width-close_bt.Width;
        //    // app_panel.AutoSize = true;
        //    app_panel.BorderStyle = System.Windows.Forms.BorderStyle.None;
        // //  app_panel.BackColor = Color.FromArgb(221, 240, 237); //242,239,230 73, 90, 128  221,240,237
        //    app_panel.Width = this.Width-formboder;
        //    app_panel.Height = this.Height-panel_under.Height-(formboder/2)-4;
        //    app_panel.Top = 0;
        //    app_panel.Left =formboder/2;
        //    //app_panel.
        //   // app_panel.AutoScroll=true;
        //    app_panel.HorizontalScroll.Visible = true;
        //    app_panel.VerticalScroll.Visible = false;
        //    app_panel.Visible = true;
        //    this.Controls.Add(panel_under);
        //    Refresh();



        //}


        //private void loadtExeBoutton()
        //{

        //    foreach (string filename in topdictionary.Keys)
        //    {

        //        int count =Convert.ToInt32( topdictionary[filename][3]);
        //        Button bt = new System.Windows.Forms.Button();
        //        ToolTip tip = new ToolTip();
        //        int space = Convert.ToInt32(app_panel.Height * 0.1);
        //        bt.Height =75;// app_panel.Height;
        //        bt.Width = bt.Height;
        //        bt.Top = 0;
        //        bt.Left = count * bt.Width;
        //        if (topdictionary[filename][1].Contains("F"))
        //        {
        //            bt.Name = "Fbt" + count;
        //        }
        //        else {
        //            bt.Name = "bt" + count;
        //        }
        //        tip.SetToolTip(bt,filename);
        //        tip.BackColor = Color.FromArgb(76, 76, 79);
        //        tip.ForeColor=Color.FromArgb(221, 240, 237);
        //        tip.IsBalloon = true;
        //        tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.None;
        //        bt.TabIndex = count;
        //        bt.Image = topimg[filename];
        //        bt.TabStop = true;
        //        bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //        bt.FlatAppearance.BorderSize = 0;
        //        bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        //        bt.Text = "";
        //        bt.UseVisualStyleBackColor = true;
        //        bt.Click += new EventHandler(bt_Click);
        //        app_panel.Controls.Add(bt);
        //    }


        //}

        private void bt_Click(object sender, EventArgs e)
        { int exeid = 0;
            Button bt = (Button)sender;
           
            string btname =bt.Name.ToString();
            if (btname.Contains("F"))
            {
          
                exeid = Convert.ToInt32(btname.Replace("Fbt", "").Trim());
                string exepath = desktop.getexepathForid(exeid);
               // MessageBox.Show("id"+exeid+"path:"+exepath);
                GetDesktop.SetupExplorer(exepath);

            }
            else
            {
                exeid = Convert.ToInt32(btname.Replace("bt", "").Trim());
                string exepath = desktop.getexepathForid(exeid);
                GetDesktop.SetupExe(exepath);
            }
           
        }
        private void logo_pic_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void applacation_bt_Enter(object sender, EventArgs e)
        {
            
        }

        private void applacation_bt_Leave(object sender, EventArgs e)
        {
          
        }

        private void applacation_bt_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void applacation_bt_MouseHover(object sender, EventArgs e)
        {

            //Button bt =(Button)sender;
            //bt.BringToFront();
            //bt.Size = new Size(bt.Size.Width * 2, bt.Height * 2);
            //panel_under.Size = new Size(panel_under.Width*2,panel_under.Height*2);
            
        }

        private void applacation_bt_MouseLeave(object sender, EventArgs e)
        {
            //Button bt = (Button)sender;
            //bt.Size = new Size(bt.Size.Width / 2, bt.Height / 2);
            //bt.Location = new Point(bt.Location.X, bt.Location.Y + 10);
            //panel_under.Size = new Size(panel_under.Width /2, panel_under.Height/2);
        }

        private void EMB_DeskTop_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                initial.CreateUserdeskTops();
                TakeFile.CreateUserdeskTop();
            }
            catch (Exception)
            {

               // throw;
            }
          
        }

        private void EMB_DeskTop_FormClosed(object sender, FormClosedEventArgs e)
        {


            try
            {
                EMB_DeskTop_FormClosing(null, null);

            }
            catch (Exception)
            {

                throw;
            }
         

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
