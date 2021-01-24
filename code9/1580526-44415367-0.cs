    public static byte[] DrawingToBytes(Drawing drawing)
    {
        DrawingVisual visual = new DrawingVisual();
        using (DrawingContext context = visual.RenderOpen())
        {
            // If using the BitmapEncoder uncomment the following line to get a white background.
            // context.DrawRectangle(Brushes.White, null, drawing.bounds);
            context.DrawDrawing(drawing);
        }
        
        int width = (int)(drawing.Bounds.Width)
        int height = (int)(drawing.Bounds.Height)
        Bitmap bmp = new Bitmap(width, height);
        Bitmap bmpOut;
        
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(System.Drawing.Color.White);
            RenderTargetBitmap rtBmp = new RenderTargetBitmap(width, height, 
                                               bmp.HorizontalResolution,
                                               bmp.VerticalResolution,
                                               PixelFormats.Pbgra32);
            rtBmp.Render(visual);
            
            // Alternative using BmpBitmapEncoder, use in place of what comes after if you wish.
            // MemoryStream stream = new MemoryStream();
            // BitmapEncoder encoder = new BmpBitmapEncoder();
            // encoder.Frames.Add(BitmapFrame.Create(rtBmp));
            // encoder.save(stream);
            
            int stride = width * ((rtBmp.Format.BitsPerPixel + 7) / 8);
            byte[] bits = new byte[height * stride];
            bitmapSource.CopyPixels(bits, stride, 0);
            
            unsafe
            {
                fixed (byte* pBits = bits)
                {
                    IntPtr ptr = new IntPtr(pBits);
                    bmpOut = new Bitmap(width, height, stride,
                                        System.Drawing.Imaging.PixelFormat.Format32bppPArgb, ptr);
                 }
            }
        
            g.DrawImage(bmpOut, 0, 0, bmp.Width, bmp.Height);
        }
    
        byte[] bytes;
        using (MemoryStream ms = new MemoryStream())
        {
            bmp.Save(ms, ImageFormat.bmp);
            data = ms.ToArray();
        }
    
        return bytes;
    }
    
