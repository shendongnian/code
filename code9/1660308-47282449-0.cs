        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                startPoint = e.Location;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Debug.WriteLine("mousemove X: " + e.X + " Y: " + e.Y);
                pictureBox1.Location = new Point(0, pictureBox1.Top + e.Location.Y - startPoint.Y);
                if (pictureBox1.Location.Y < 0)
                {
                    pictureBox1.Location = new Point(0, 0);
                    dragging = false;
                }
                if (pictureBox1.Location.Y > 100)
                {
                    pictureBox1.Location = new Point(0, 100);
                    dragging = false;
                }
                this.Refresh();
            }
            int n = pictureBox1.Location.Y;
            n = n * -1 + 100;
            label1.Text = n.ToString();
            mediaPlayer1.settings.volume = n;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
