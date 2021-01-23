    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace ProgressBar
    {
        public partial class PBar : UserControl
        {
            public PBar()
            {
                InitializeComponent();
            }
            private void panel1_Paint(object sender, PaintEventArgs e)
            {
                
            }
            int incre = 0;
       
            private void timer1_Tick(object sender, EventArgs e)
            {
                int width = 15;
                int gap = 5;
                Graphics g = panel1.CreateGraphics();
                g.Clear(panel1.BackColor);
                SolidBrush blueBrush = new SolidBrush(Color.DarkBlue);
                g.FillRectangle(blueBrush, new Rectangle(new Point(incre, 0), new Size(width, panel1.Height - 1)));
                g.FillRectangle(blueBrush, new Rectangle(new Point(incre + width + gap, 0), new Size(width, panel1.Height - 1)));
                g.FillRectangle(blueBrush, new Rectangle(new Point(incre + 2 * (width + gap), 0), new Size(width, panel1.Height - 1)));
                g.FillRectangle(blueBrush, new Rectangle(new Point(incre + 3* (width + gap), 0), new Size(width, panel1.Height - 1)));
            
                incre += 10;
                if (incre > panel1.Width)
                    incre = 0;
            }
        }
    }
