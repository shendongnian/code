    private struct POINT
    {
        public int x;
        public int y;
    }
    
    private struct MINMAXINFO
    {
        public POINT ptReserved;
        public POINT ptMaxSize;
        public POINT ptMaxPosition;
        public POINT ptMinTrackSize;
        public POINT ptMaxTrackSize;
    }
    /**Other Code**/
    
    MINMAXINFO* minMaxInfo = (MINMAXINFO*) lParam;
    
    int currentMaxSize = minMaxInfo->ptMaxSize.x;
    Debug.WriteLine("Updated max" + currentMaxSize);
    
    minMaxInfo->ptMaxSize.x = screenWidth; 
    minMaxInfo->ptMaxSize.y = screenHeight;
    
    User32.SetWindowPos(wParam, User32.SpecialWindowHandles.HWND_TOP, 0, 0, screenWidth, screenHeight, User32.SetWindowPosFlags.SWP_DRAWFRAME | User32.SetWindowPosFlags.SWP_ASYNCWINDOWPOS);
    
    /**Other Code**/
