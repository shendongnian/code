        int x, y;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Graphics graph = Graphics.FromImage(image);
            if (e.Button == MouseButtons.Left)
            {
                graph.DrawLine(Pens.Red, From.X, From.Y, e.X, e.Y);
                pictureBox1.Image = image;
                x = e.X;
                y = e.Y;
            }
        }
