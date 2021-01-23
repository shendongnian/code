    public static Rectangle GetTaskbarPosition()
    {
        APPBARDATA data = new APPBARDATA();
        data.cbSize = Marshal.SizeOf(data);
        IntPtr retval = SHAppBarMessage(ABM_GETTASKBARPOS, ref data);
        if (retval == IntPtr.Zero)
        {
            throw new Win32Exception("Please re-install Windows");
        }
        return new Rectangle(data.rc.left, data.rc.top, data.rc.right - data.rc.left, data.rc.bottom - data.rc.top);
    }
    public static Color GetColourAt(Point location)
    {
        using (Bitmap screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb))
        using (Graphics gdest = Graphics.FromImage(screenPixel))
        {
            using (Graphics gsrc = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr hSrcDC = gsrc.GetHdc();
                IntPtr hDC = gdest.GetHdc();
                int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, location.X, location.Y, (int)CopyPixelOperation.SourceCopy);
                gdest.ReleaseHdc();
                gsrc.ReleaseHdc();
            }
            return screenPixel.GetPixel(0, 0);
        }
    }
