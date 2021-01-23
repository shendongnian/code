            [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(HandleRef hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr WindowHandle);
        public const int SW_RESTORE = 9;
        static void Main(string[] args)
        {
            Process process = System.Diagnostics.Process.GetProcessesByName("POWERPNT").FirstOrDefault();
            IntPtr hWnd = IntPtr.Zero;
            hWnd = process.MainWindowHandle;
            ShowWindowAsync(new HandleRef(null, hWnd), SW_RESTORE);
            SetForegroundWindow(process.MainWindowHandle);
        }
