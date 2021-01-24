        private void Form1_Load(object sender, EventArgs e)
        {
            // Your Solution
            int x = 0, y = 0;
            pictureBox1.Paint += new PaintEventHandler(delegate(object sender2, PaintEventArgs e2)
            {
                e2.Graphics.FillRectangle(Brushes.Green, x, y, 10, 10);
            });
            // Test
            buttonTest1.Click += new EventHandler(delegate(object sender2, EventArgs e2)
            {
                x++;
                pictureBox1.Invalidate();
            });
            buttonTest2.Click += new EventHandler(delegate(object sender2, EventArgs e2)
            {
                for (x = 0; x < pictureBox1.Width - 10; x++)
                {
                    System.Threading.Thread.Sleep(50);
                    pictureBox1.Invalidate();
                    pictureBox1.Refresh();
                }
            });
            buttonTest3.Click += new EventHandler(delegate(object sender2, EventArgs e2)
            {
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Tick += new EventHandler(delegate(object sender3, EventArgs e3)
                {
                    if (x <= pictureBox1.Width - 10)
                        x++;
                    pictureBox1.Invalidate();
                });
                t.Enabled = true;
                t.Interval = 50;
            });
        }
