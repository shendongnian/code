      [DllImport("user32.dll")]
      private static extern IntPtr GetForegroundWindow();
    
      [DllImport("user32.dll")]
      internal static extern short GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
            
      [DllImport("user32.dll")]
      internal static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
    
      public struct RECT
      {
        public RECT(int l, int t, int r, int b)
        {
          Left = l;
          Top = t;
          Right = r;
          Bottom = b;
        }
    
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
      }
    
      public struct POINT
      {
        public POINT(int x, int y)
        {
          X = x;
          Y = y;
        }
    
        public int X;
        public int Y;
    
      }
  
      public struct WINDOWPLACEMENT
          {
            public int length;
            public int flags;
            public ShowWindowEnum showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
          }
        
         public enum ShowWindowEnum : uint
         {
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            SW_SHOWMINIMIZED = 2,
         }
        
         private void MinimizeForegroundWindow()
         {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            GetWindowPlacement(_handle, ref placement);
            if (placement.showCmd != ShowWindowEnum.SW_SHOWMINIMIZED)
            {
                ShowWindow(_handle, ShowWindowEnum.SW_SHOWMINIMIZED);
            }
         }
