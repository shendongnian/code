    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace AppHost
    {
        class Program
        {
            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();
    
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
            const int SW_HIDE = 0;
    
            private static void Main(string[] args)
            {
                var handle = GetConsoleWindow();
                ShowWindow(handle, SW_HIDE);
    
                var start = new ProcessStartInfo { FileName = args[0] };
    
                var process = Process.Start(start);
                process.WaitForExit();
            }
        }
    }
