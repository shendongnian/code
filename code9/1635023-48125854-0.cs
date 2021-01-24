    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace EdgeApp
    {
        class Program
        {
            [DllImport("user32.dll")]
            private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            private static extern int GetWindowTextLength(IntPtr hWnd);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    
            [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
            private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    
            public const int SW_HIDE = 0;
            public const int SW_SHOWNORMAL = 1;
            public const int SW_SHOWMINIMIZED = 2;
            public const int SW_SHOWMAXIMIZED = 3;
    
            public static void Main(string[] args)
            {
                // Enumerate over windows.
                EnumWindows((handle, param) =>
                {
                    // Get the class name. We are looking for ApplicationFrameWindow.
                    var className = new StringBuilder(256);
                    GetClassName(handle, className, className.Capacity);
    
                    // Get the window text. We're looking for Microsoft Edge.
                    int windowTextSize = GetWindowTextLength(handle);
                    var windowText = new StringBuilder(windowTextSize + 1);
                    GetWindowText(handle, windowText, windowText.Capacity);
    
                    // Check if we have a match. If we do, minimize that window.
                    if (className.ToString().Contains("ApplicationFrameWindow") && 
                        windowText.ToString().Contains("Microsoft Edge"))
                    {
                        ShowWindow(handle, SW_SHOWMINIMIZED);
                    }
    
                    // Return true so that we continue enumerating,
                    // in case there are multiple instances.
                    return true;
                }, IntPtr.Zero);
            }
        }
    }
