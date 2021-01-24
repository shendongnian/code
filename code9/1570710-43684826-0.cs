        Pen p = new Pen(Color.Red, 3);
        SolidBrush b = new SolidBrush(Color.Red);
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            p.Color = Color.Blue;
            b.Color = Color.Blue;
            g.FillEllipse(b, e.X, e.Y, 50, 50);
            g.DrawEllipse(p, e.X, e.Y, 50, 50);
            g.Dispose();
        }
