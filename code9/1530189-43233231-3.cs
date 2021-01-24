    internal static class IconUtilities
    {
        public static ImageSource ToImageSource(this Bitmap bitmap)
        {
            if (bitmap == null) throw new ArgumentNullException("bitmap");
    
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
