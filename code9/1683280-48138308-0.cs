    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                int Y = 20;
                for (int row = 0; row <= 19; row++)
                {
                    int X = 25;
                    for (int col = 0; col <= 29; col++)
                    {
                        PictureBox box = new PictureBox();
                        Graphics graphicsObj = box.CreateGraphics();
                        graphicsObj.FillEllipse(Brushes.Blue, X, Y, 5, 5);
                        X += 25;
                        box.Click += new EventHandler(Box_Click);
                        
                    }
                    Y += 20;
                }
                
            }
            private void Box_Click(object sender, EventArgs e)
            {
            }
        }
    }
