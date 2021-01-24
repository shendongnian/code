        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);
    
        public static bool isTouchScreen()
        {
            int MAX_TOUCHES = 0x95;
            int maxTouches = GetSystemMetrics(MAX_TOUCHES);
    
            return maxTouches > 0;
        }
