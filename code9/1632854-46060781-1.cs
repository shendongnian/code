        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int x = pictureBox1.Location.X;
            int y = pictureBox1.Location.Y;
            if (e.KeyCode == Keys.Right) { x += 1; }
            else if (e.KeyCode == Keys.Left) { x -= 1; }
            else if (e.KeyCode == Keys.Up) { y -= 1; }
            else if (e.KeyCode == Keys.Down) { y += 1; }
            pictureBox1.Location = new Point(x, y);
        }
