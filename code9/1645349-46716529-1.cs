    public bool SixStarMax()
    {
        Rectangle rect = new Rectangle(1980, 630, 1240, 180);
    
        Bitmap bitmapToScan = GetScreenPart(rect);
    
        Point?[] autoSumPoints = new Point?[4];
    
        autoSumPoints[0] = SearchForColor(bitmapToScan, 0xF8F0E0);
        autoSumPoints[1] = SearchForColor(bitmapToScan, 0xB7AD9F);
        autoSumPoints[2] = SearchForColor(bitmapToScan, 0xCDC6B8);
        autoSumPoints[3] = SearchForColor(bitmapToScan, 0x949084);
    
        //return true if all points return a value
        bool containsAll = autoSumPoints.All(p => p.HasValue);
    
        if (containsAll) Cursor.Position = autoSumPoints[0].Value;
        return containsAll;
    }
    
    public Bitmap GetScreenPart(Rectangle rect)
    {
        //initialize bitmap
        Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
    
        //fill bitmap
        using (Graphics g = Graphics.FromImage(bmp))
            g.CopyFromScreen(new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Bottom), rect.Size);
    
        return bmp;
    }
    
    public Point? SearchForColor(Bitmap image, uint color)
    {
        Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
    
        BitmapData data = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
    
        //works for 32-bit pixel format only
        int ymin = rect.Top, ymax = Math.Min(rect.Bottom, image.Height);
        int xmin = rect.Left, xmax = Math.Max(rect.Right, image.Width) - 1;
    
        int strideInPixels = data.Stride / 4; //4 bytes per pixel
        unsafe
        {
            uint* dataPointer = (uint*)data.Scan0;
            for (int y = ymin; y < ymax; y++)
                for (int x = xmin; x < xmax; x++)
                {
                    //works independently of the data.Stride sign
                    uint* pixelPointer = dataPointer + y * strideInPixels + x;
                    uint pixel = *pixelPointer;
                    bool found = pixel == color;
                    if (found)
                    {
   
                        image.UnlockBits(data);
                        return new Point(x, y);
    
                    }
                }
        }
        image.UnlockBits(data);
        return null;
    }
