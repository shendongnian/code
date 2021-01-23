    BitmapSource ScreenShot(int x, int y, int width, int height)
    {
        using (var screenBitmap = new Bitmap(width,height,System.Drawing.Imaging.PixelFormat.Format32bppArgb))
        {
            using (var g = Graphics.FromImage(screenBitmap))
            {
                g.CopyFromScreen(x, y, 0, 0, screenBitmap.Size);
                var result = Imaging.CreateBitmapSourceFromHBitmap(
                    screenBitmap.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
                return result;
            }
        }
    }
