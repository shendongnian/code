    // Create a Bitmap object from a file.
    using (var ms = new MemoryStream(data))
    {
       bmp = new Bitmap(ms);
       Rectangle cloneRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
       System.Drawing.Imaging.PixelFormat format = bmp.PixelFormat;
       this.bitmap = bmp.Clone(cloneRect, bmp.PixelFormat);    
    }
