    [DllImport("coredll.dll")]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    [DllImport("coredll.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int nMsg, IntPtr wParam, IntPtr lParam);
    
    private const int WM_MOUSEMOVE = 0x0200;
    
    public static void RefreshTrayArea()
    {
        // The client rectangle can be determined using "GetClientRect" (from coredll.dll) but
        // does require the taskbar to be visible. The values used in the loop below were
        // determined empirically.
        IntPtr hTrayWnd = FindWindow("HHTaskBar", null);
        if (hTrayWnd != IntPtr.Zero)
        {
            int nStartX = (Screen.PrimaryScreen.Bounds.Width / 2);
            int nStopX = Screen.PrimaryScreen.Bounds.Width;
            int nStartY = 0;
            int nStopY = 26;    // From experimentation...
            for (int nX = nStartX; nX < nStopX; nX += 10)
                for (int nY = nStartY; nY < nStopY; nY += 5)
                    SendMessage(hTrayWnd,
                        WM_MOUSEMOVE, IntPtr.Zero, (IntPtr)((nY << 16) + nX));
        }
    }
