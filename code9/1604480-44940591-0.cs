    static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
    {
        var ratioX = (double)maxWidth / image.Width;
        var ratioY = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratioX, ratioY);
    
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
    
        using (Bitmap newImage = new Bitmap(newWidth, newHeight))
        {
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
    
                Bitmap bmp = new Bitmap(newImage);
                return bmp;
            }
        } 
    }
