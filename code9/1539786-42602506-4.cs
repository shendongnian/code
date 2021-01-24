    var bmp = new Bitmap(pictureBox1.Image);
    var img = new LockBitmap(bmp);
    img.LockBits();
    Color c;
    //...
    //...
    //...
    img.UnlockBits();
    pictureBox1.Image = bmp;
    MessageBox.Show("Complete");
