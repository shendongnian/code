        [StructLayout(LayoutKind.Sequential)]
        struct Point
        {
            public int X;
            public int Y;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEHOOKSTRUCT
        {
            public Point pt;
            public IntPtr hwnd;
            public uint wHitTestCode;
            public IntPtr dwExtraInfo;
        }
        
        private int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                // Do something.
                var mhs = Marshal.PtrToStructure<MOUSEHOOKSTRUCT>(lParam);
                Console.WriteLine($"point: {mhs.pt.X} {mhs.pt.Y}");
            }
            return CallNextHookEx(this.hookID, nCode, wParam, lParam);
        }
