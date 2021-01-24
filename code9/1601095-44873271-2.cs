    private const int WM_NCHITTEST = 0x0084;
    private const int WM_NCMOUSEMOVE = 0x00a0;
    private const int WM_NCMOUSELEAVE = 0x02a2;
    private enum HtResult
    {
        HTERROR = (-2),
        HTTRANSPARENT = (-1),
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTCAPTION = 2,
        HTSYSMENU = 3,
        HTGROWBOX = 4,
        HTSIZE = HTGROWBOX,
        HTMENU = 5,
        HTHSCROLL = 6,
        HTVSCROLL = 7,
        HTMINBUTTON = 8,
        HTMAXBUTTON = 9,
        HTLEFT = 10,
        HTRIGHT = 11,
        HTTOP = 12,
        HTTOPLEFT = 13,
        HTTOPRIGHT = 14,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HTREDUCE = HTMINBUTTON,
        HTZOOM = HTMAXBUTTON,
        HTSIZEFIRST = HTLEFT,
        HTSIZELAST = HTBOTTOMRIGHT,
        HTOBJECT = 19,
        HTCLOSE = 20,
        HTHELP = 21
    }
    [Flags]
    public enum TMEFlags : uint
    {
        TME_CANCEL = 0x80000000,
        TME_HOVER = 0x00000001,
        TME_LEAVE = 0x00000002,
        TME_NONCLIENT = 0x00000010,
        TME_QUERY = 0x40000000
    }
    [DllImport("user32.dll")]
    static extern int TrackMouseEvent(ref TRACKMOUSEEVENT lpEventTrack);
    [StructLayout(LayoutKind.Sequential)]
    public struct TRACKMOUSEEVENT
    {
        public int cbSize;
        public TMEFlags dwFlags;
        public IntPtr hwndTrack;
        public int dwHoverTime;
    }
    private bool _trackingMouseMove;
    private TRACKMOUSEEVENT _tme;
    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == WM_NCMOUSEMOVE)
        {
            if (!_trackingMouseMove)
            {
                _tme = new TRACKMOUSEEVENT();
                _tme.hwndTrack = hwnd;
                _tme.cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
                _tme.dwFlags = TMEFlags.TME_NONCLIENT | TMEFlags.TME_LEAVE;
                int success = TrackMouseEvent(ref _tme);
                _trackingMouseMove = (success != 0);
            }
            var hitTestResult = (HtResult)wParam;
            if ((hitTestResult == HtResult.HTSYSMENU) || (hitTestResult == HtResult.HTCAPTION))
            {
                // Raise event here
                System.Diagnostics.Debug.WriteLine("Mouse over title bar");
            }
        }
        else if (msg == WM_NCMOUSELEAVE)
        {
            _trackingMouseMove = false;
            System.Diagnostics.Debug.WriteLine("Mouse left the title bar");
        }
        return IntPtr.Zero;
    }
