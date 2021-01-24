    if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
    bitmap.Save("C:\\1.jpg");
    bitmap.Dispose();
    using (Bitmap bm = new Bitmap(C:\\1.jpg"))
    {
       pictureBox2.Image = new Bitmap(bm);
    };
