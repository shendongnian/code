    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Drawing;
    
    namespace GrafikaTeszt
    {
        class Class1
        {
            public int ticks;
            public bool flashing;
    
            public void draw(Graphics g, out bool stop)
            {
                stop = false;
                if (ticks % 2 == 0)
                {
                    red();  //draw a red line
                }
                else
                {
                    dark();     //draw a darkred line
                }
    
                if (ticks == 20)
                {
                    stop = true;
                }
    
                void red() { g.DrawLine(Pens.Red, 100, 100, 500, 500); }
                void dark() { g.DrawLine(Pens.DarkRed, 100, 100, 500, 500); }
            }
    
            public Class1()
            {
                flashing = false;
            }
        }
    }
