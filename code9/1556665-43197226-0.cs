        private const uint PM_REMOVE = 0x1;
        private const uint WM_MOUSEFIRST = 0x0200;
        private const uint WM_MOUSELAST = 0x0209;
        private const uint WM_QUIT = 0x0012;
        private struct Message
        {
            long hwnd;
            long message;
            long wParam;
            long lParam;
            long time;
            Point pt;
        }
        #if WindowsCE
        [DllImport("coredll.dll")]
        #else
        [DllImport("Kernel32.dll")]
        #endif
    private extern static bool PeekMessage(out Message Msg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
      public void ClearMouseClickQueue()
            {  Message msg;
        while (PeekMessage(out msg, IntPtr.Zero, WM_MOUSEFIRST,WM_MOUSELAST, 1) != false){ }} 
   
