    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int xCoordinate = e.X;
            int yCoordinate = e.Y;
            var picture = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(e.X, e.Y),
                Image = Image.FromFile("pushpin.png"),
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            this.Controls.Add(picture);
            picture.BringToFront();
        }
