    undoImage = pictureBox1.BackgroundImage.Clone() as Image;
    Bitmap sourceBitmap = new Bitmap(pictureBox1.BackgroundImage, pictureBox1.Width, pictureBox1.Height);
    using (Graphics g = Graphics.FromImage(sourceBitmap))
    {
          g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox2.Width,pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);
    }
    pictureBox1.BackgroundImage = sourceBitmap;
