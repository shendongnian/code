    using System;
    using System.Windows;
    using System.Windows.Interop;
    using System.Runtime.InteropServices;
    
    namespace YourSolution
    {
        static class WindowExtensions
        {
            [DllImport("User32.dll")]
            internal static extern bool SetForegroundWindow(IntPtr hWnd);
            
            public static void SetFocus(this Window window)
            {
                var handle = new WindowInteropHelper(window).Handle;
                SetForegroundWindow(handle);
            }
        }
    }
