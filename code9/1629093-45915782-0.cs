    public static class WindowHelper
    {
        [DllImport("user32.dll")]
        static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        public static void DisableWindow(Window window)
        {
            EnableWindow(new WindowInteropHelper(window).EnsureHandle(), false);
        }
        public static void EnableWindow(Window window)
        {
            EnableWindow(new WindowInteropHelper(window).EnsureHandle(), true);
        }
    }
