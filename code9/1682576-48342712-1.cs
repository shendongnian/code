    public static Bitmap CreateWithNewSize(Image image, Int32 newWidth, Int32 newHeight)
    {
        Bitmap bp = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
        using (Graphics gr = Graphics.FromImage(bp))
            gr.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
        return bp;
    }
