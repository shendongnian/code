    class Program
    {
        private static System.Timers.Timer _timer = new System.Timers.Timer(333);
        private static IntPtr _vs2017Handle;
        private const int WM_NCHITTEST = 0x0084;
        
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
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
        static void Main(string[] args)
        {
            _vs2017Handle = System.Diagnostics.Process.GetProcessesByName("devenv")[0].MainWindowHandle;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            System.Windows.Forms.Application.Run();
        }
        private static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var cursorPosition = System.Windows.Forms.Cursor.Position;
            IntPtr lParam = new IntPtr(cursorPosition.X | (cursorPosition.Y << 16));
            var result = (HtResult)SendMessage(_vs2017Handle, WM_NCHITTEST, IntPtr.Zero, lParam);
            bool isOverTitleBar = (result == HtResult.HTSYSMENU) || (result == HtResult.HTCAPTION);
            Console.WriteLine(isOverTitleBar.ToString() + " (" + result.ToString() + ")");
        }
    }
