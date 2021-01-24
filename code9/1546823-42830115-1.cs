    private BitmapSource MakeScreenshot(Screen screen)
    {
        using (var screenBmp = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb))
        {
            using (var bmpGraphics = Graphics.FromImage(screenBmp))
            {
                bmpGraphics.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size);
                var handle = screenBmp.GetHbitmap();
                try {
                    return
                        Imaging.CreateBitmapSourceFromHBitmap(
                            handle,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                }
                finally {
                    DeleteObject(handle);
                }
            }
        }
    }
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
