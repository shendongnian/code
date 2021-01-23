    Bitmap bmp = new Bitmap(50, 50);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.DrawArc(Pens.Black, new Rectangle(0, 0, 50, 50), 0, 90);
    }
