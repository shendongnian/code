    internal static class NativeMethods
        {
            //Codes for suspending painting (for fast loading)
            [DllImport("user32.dll")]
            public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
            public static uint WM_SETREDRAW = 11;
        }
