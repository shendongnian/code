    static class TouchKeyboard
    {
        public static bool GetIsOpen()
        {
            return GetIsOpen1709() ?? GetIsOpenLegacy();
        }
        private static bool? GetIsOpen1709()
        {
            var parent = IntPtr.Zero;
            for (;;)
            {
                parent = FindWindowEx(IntPtr.Zero, parent, WindowParentClass1709);
                if (parent == IntPtr.Zero)
                    return null; // no more windows, keyboard state is unknown
                // if it's a child of a WindowParentClass1709 window - the keyboard is open
                var wnd = FindWindowEx(parent, IntPtr.Zero, WindowClass1709, WindowCaption1709);
                if (wnd != IntPtr.Zero)
                    return true;
            }
        }
        private static bool GetIsOpenLegacy()
        {
            var wnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, WindowClass);
            if (wnd == IntPtr.Zero)
                return false;
            var style = GetWindowStyle(wnd);
            return style.HasFlag(WindowStyle.Visible)
                && !style.HasFlag(WindowStyle.Disabled);
        }
        private const string WindowClass = "IPTip_Main_Window";
        private const string WindowParentClass1709 = "ApplicationFrameWindow";
        private const string WindowClass1709 = "Windows.UI.Core.CoreWindow";
        private const string WindowCaption1709 = "Microsoft Text Input Application";
        private enum WindowStyle : uint
        {
            Disabled = 0x08000000,
            Visible = 0x10000000,
        }
        private static WindowStyle GetWindowStyle(IntPtr wnd)
        {
            return (WindowStyle)GetWindowLong(wnd, -16);
        }
        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr FindWindowEx(IntPtr parent, IntPtr after, string className, string title = null);
        [DllImport("user32.dll", SetLastError = false)]
        private static extern uint GetWindowLong(IntPtr wnd, int index);
    }
