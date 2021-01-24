    public static Bitmap ResizeImage(Bitmap image, Size size)
    {
        try
        {
            Bitmap result = new Bitmap(size.Width, size.Height);
    
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;
    
                g.DrawImage(image, 0, 0, size.Width, size.Height);
            }
    
            return result;
        }
        catch 
        {
            return image; 
        }
    }
