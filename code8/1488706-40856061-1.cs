    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    IntPtr hBitmap = bitmap.GetHbitmap();
    try
    {
        imageSource = Imaging.CreateBitmapSourceFromHBitmap(hBitmap,
                                                            IntPtr.Zero,
                                                            Int32Rect.Empty,
                                                            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
    catch (Exception e) { }
    finally
    {
        DeleteObject(hBitmap);
    }
