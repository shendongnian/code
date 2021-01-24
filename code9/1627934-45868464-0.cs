        private void timer1_Tick_1(object sender, EventArgs e)
        {
            int x = panel2.Size.Width;
            int y = panel2.Size.Height;
            panel2.Size = new Size(x + 10, y);
            panel2.Location = new Point(panel2.Location.X - 10, panel2.Location.Y);
            if (x>150)
            {
                timer1.Stop();
            }
        }
