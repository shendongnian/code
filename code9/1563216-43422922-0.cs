    public BitmapSource ImageToBitmapSource(System.Drawing.Image image)
    {
            var bitmap = new System.Drawing.Bitmap(image);
            var bitSrc =BitmapToBitmapSource(bitmap);
            bitmap.Dispose();
            bitmap = null;
            return bitSrc;
    }
    public BitmapSource BitmapToBitmapSource(System.Drawing.Bitmap source)
    {
            BitmapSource bitSrc = null;
            var hBitmap = source.GetHbitmap();
            try
            {
                bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch (Win32Exception)
            {
                bitSrc = null;
            }
           
            return bitSrc;
    }
