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
            const int ROWS = 3;
            const int COLUMNS = 4;
            const int WIDTH = 10;
            const int HEIGHT = 20;
            const int SPACE = 10;
            public Form1()
            {
                InitializeComponent();
                Panel panel = new Panel();
                panel.Width = COLUMNS * (WIDTH + SPACE);
                panel.Height = ROWS * (HEIGHT + SPACE);
                this.Controls.Add(panel);
                for (int rows = 0; rows < ROWS; rows++)
                {
                    for (int cols = 0; cols < COLUMNS; cols++)
                    {
                        PictureBox newPictureBox = new PictureBox();
                        newPictureBox.Width = WIDTH;
                        newPictureBox.Height = HEIGHT;
                        newPictureBox.Top = rows * (HEIGHT + SPACE);
                        newPictureBox.Left = cols * (WIDTH + SPACE);
                        panel.Controls.Add(newPictureBox);
                        newPictureBox.Paint +=new PaintEventHandler(pictureBox_Paint);
                    }
                }
            }
            private void pictureBox_Paint(object sender, PaintEventArgs e) {
                Rectangle ee = new Rectangle(0, 0, WIDTH, HEIGHT);           
                using (Pen pen = new Pen(Color.Red, 2)) {
                    e.Graphics.DrawRectangle(pen, ee);
                }
            }
         }
    }
