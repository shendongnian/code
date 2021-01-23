    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
       
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Paint += new PaintEventHandler(this_Paint);
            }
            private void this_Paint(object sender, PaintEventArgs e)
            {
                Pen pen = new Pen(Color.Green, 2.0F);
                pen.DashStyle = DashStyle.Dash;
                foreach (Control c in groupBox1.Controls)
                {
                    e.Graphics.DrawRectangle(pen, (groupBox1.Location.X + c.Location.X)-1, (groupBox1.Location.Y + c.Location.Y)-1, c.Width + 2, c.Height + 2);
                }
                pen.Dispose();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                
            }
        }
    }
