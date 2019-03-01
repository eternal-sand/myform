namespace MyForm
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.closebt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.appbt = new System.Windows.Forms.Button();
            this.wordbt = new System.Windows.Forms.Button();
            this.minboxbt = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closebt
            // 
            this.closebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.closebt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closebt.FlatAppearance.BorderSize = 0;
            this.closebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.closebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.closebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebt.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closebt.Location = new System.Drawing.Point(853, 3);
            this.closebt.Name = "closebt";
            this.closebt.Size = new System.Drawing.Size(44, 24);
            this.closebt.TabIndex = 0;
            this.closebt.Text = "退出";
            this.closebt.UseVisualStyleBackColor = false;
            this.closebt.Click += new System.EventHandler(this.closebt_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.appbt);
            this.panel1.Controls.Add(this.wordbt);
            this.panel1.Controls.Add(this.minboxbt);
            this.panel1.Controls.Add(this.closebt);
            this.panel1.Location = new System.Drawing.Point(2, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 33);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.textBox1.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.textBox1.Location = new System.Drawing.Point(81, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(143, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "关键字";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "应用查找：";
            // 
            // appbt
            // 
            this.appbt.AllowDrop = true;
            this.appbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.appbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.appbt.FlatAppearance.BorderSize = 0;
            this.appbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.appbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.appbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appbt.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.appbt.Location = new System.Drawing.Point(666, 3);
            this.appbt.Name = "appbt";
            this.appbt.Size = new System.Drawing.Size(44, 24);
            this.appbt.TabIndex = 0;
            this.appbt.Text = "应用";
            this.toolTip1.SetToolTip(this.appbt, "应用");
            this.appbt.UseVisualStyleBackColor = false;
            // 
            // wordbt
            // 
            this.wordbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.wordbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wordbt.FlatAppearance.BorderSize = 0;
            this.wordbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.wordbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.wordbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wordbt.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wordbt.Location = new System.Drawing.Point(726, 4);
            this.wordbt.Name = "wordbt";
            this.wordbt.Size = new System.Drawing.Size(44, 24);
            this.wordbt.TabIndex = 0;
            this.wordbt.Text = "文档";
            this.wordbt.UseVisualStyleBackColor = false;
            // 
            // minboxbt
            // 
            this.minboxbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(66)))));
            this.minboxbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minboxbt.FlatAppearance.BorderSize = 0;
            this.minboxbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.minboxbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.minboxbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minboxbt.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.minboxbt.Location = new System.Drawing.Point(798, 3);
            this.minboxbt.Name = "minboxbt";
            this.minboxbt.Size = new System.Drawing.Size(44, 24);
            this.minboxbt.TabIndex = 0;
            this.minboxbt.Text = "—";
            this.minboxbt.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(46)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(911, 110);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closebt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button appbt;
        private System.Windows.Forms.Button wordbt;
        private System.Windows.Forms.Button minboxbt;
        private System.Windows.Forms.ToolTip toolTip1;
        //   private System.Windows.Forms.ProgressBar progressBar1;//注释此句
        // private Myprogrambar progressBar1; //新添此句，添加新的控件MyProgressBar
    }
}

