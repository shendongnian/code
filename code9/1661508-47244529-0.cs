        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        public BitmapSource GetScreenBitmap(Win32Point point, int size)
        {
            var bm = new Bitmap(size, size, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            var bmpGraphics = Graphics.FromImage(bm);
            bmpGraphics.CopyFromScreen(point.X - (size / 2), point.Y - (size / 2), 0, 0, bm.Size);
            IntPtr hBitmap = bm.GetHbitmap();
            var bmpS = Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            DeleteObject(hBitmap);
            return bmpS;
        }
