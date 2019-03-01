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
    public partial class Form2 : Form
    {
        const double pi1 = Math.PI / 180;
        double q = 0;
        string path1="";
        string path2 = "";
        string path3 = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            path1 = Application.StartupPath + "\\img\\1.jpg";
           path2 = Application.StartupPath+"\\img\\2.jpg";
           path3 = Application.StartupPath + "\\img\\3.jpg";
           pictureBox1.Image = Image.FromFile(path1);
           pictureBox2.Image = Image.FromFile(path2); 
            pictureBox3.Image = Image.FromFile(path3);

           timer1.Enabled=true;
           timer1.Interval = 100;

        }

        private void picaction(PictureBox p)
        {
            p.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            picaction(pictureBox1);
            pictureBox1.Left = Convert.ToInt32(panel1.Width / 2 +130* Math.Cos(q));
            pictureBox1.Top = Convert.ToInt32(panel1.Height / 2 + 130 * Math.Sin(q));
            q += pi1;
            Refresh();
            
        }
    }
}
