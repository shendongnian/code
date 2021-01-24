    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace GrafikaTeszt
    {
        public partial class Form1 : Form
        {
            Timer clock;
            Class1 classic;
            bool stop;
    
            public Form1()
            {
                InitializeComponent();
                clock = new Timer();
                clock.Interval = 200;
                clock.Tick += new EventHandler(ticked);
                classic = new Class1();
                stop = false;
            }
    
            void ticked(object sender, EventArgs e)
            {
                classic.ticks++;
                Invalidate();
            }
    
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                if (classic.flashing)
                {
                    classic.draw(e.Graphics, out stop);
                    if (stop)
                    {
                        clock.Stop();
                        classic.flashing = false;
                        Invalidate();
                    }
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                clock.Start();
                classic.flashing = true;
                classic.ticks = 0;
            }
        }
    }
