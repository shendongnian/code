       public BitmapSource convertBitmap(Bitmap source)
            {
                return Imaging.CreateBitmapSourceFromHBitmap(source.GetHbitmap(), IntPtr.Zero,
         Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
    
    
     IntPtr frame = GetBlankFrame();
                    Bitmap blank = new Bitmap(600, 800, 3 * 600, System.Drawing.Imaging.PixelFormat.Format24bppRgb, frame);
    
                    BitmapSource src = convertBitmap(blank);
