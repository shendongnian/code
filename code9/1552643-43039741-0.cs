    public static Bitmap GetCopyOf(Bitmap originalImage)
        {
        Bitmap copy = new Bitmap(originalImage.Width, originalImage.Height);
        using (Graphics graphics = Graphics.FromImage(copy))
        {
          Rectangle imageRectangle = new Rectangle(0, 0, copy.Width, copy.Height);
          graphics.DrawImage( originalImage, imageRectangle, imageRectangle, GraphicsUnit.Pixel);
        }
        return copy;
        }
