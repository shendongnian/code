    int width = 100;
    int height = 100;
    Image image = new Bitmap(width, height);
    
    using (var graphics = Graphics.FromImage(image))
    {
        graphics.DrawImage(MyApplication.Properties.Resources.ImageItemX, new Rectangle(0, 0, width, height));
        graphics.DrawImage(MyApplication.Properties.Resources.ImageGradeZ, new Rectangle(0, 0, width, height));
    }
    
    myPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
    myPictureBox.Image = image;
