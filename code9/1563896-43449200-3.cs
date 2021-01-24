     [DllImport("User32.dll")]
     private static extern IntPtr WindowFromDC(IntPtr hDC);
     // override: depending on MyClass it can be protected virtual void...
     protected override void OnPaint(PaintEventArgs e) {
       ...
       IntPtr hDC = e.Graphics.GetHdc();
       try {
         IntPtr hWnd = WindowFromDC(hDC);
         ...
       }
       finally {
         e.Graphics.ReleaseHdc(hDC);
       }
     }
