    public static Image ScaleImage(Image image, int height)
    {
        double ratio = (double)height/ image.Height;
        int newWidth = (int)(image.Width * ratio);
        int newHeight = (int)(image.Height * ratio);
        Bitmap newImage = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, 0, 0, newWidth, newHeight);
        }
        image.Dispose();
        return newImage;
    }
