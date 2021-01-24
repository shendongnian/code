        private void button1_Click(object sender, EventArgs e)
        {
            var image = new Bitmap( this.pictureBox1.Image.Width, this.pictureBox1.Image.Height);
            var rect = new Rectangle(0, 0, this.pictureBox1.Image.Width, this.pictureBox1.Image.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(this.pictureBox1.Image, 0, 0);
            var waterMarkImage = new Bitmap(this.pictureBox2.Image.Width, this.pictureBox2.Image.Height);
            for (int y = 0; y < waterMarkImage.Height; y++)
            {
                for (int x = 0; x < waterMarkImage.Width; x++)
                {
                    var color = (this.pictureBox2.Image as Bitmap).GetPixel(x, y);
                    color = Color.FromArgb(50, color.R, color.G, color.B);
                    waterMarkImage.SetPixel(x, y, color);
                }
            }
            graphics.DrawImage(waterMarkImage, rect);
            this.pictureBox3.Image = image;
        }
