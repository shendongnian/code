            //aktivneOknoProces
            string aktivneOknoProces = GetActiveProcess();
    
    private string GetActiveProcess()
            {
                string app = "";
                var foregroundProcess = Process.GetProcessById(WinAPIFunctions.GetWindowProcessId(WinAPIFunctions.GetforegroundWindow()));
                if (foregroundProcess.ProcessName == "ApplicationFrameHost")
                {
                    foregroundProcess = GetRealProcess(foregroundProcess);
                }
                if(foregroundProcess != null)
                {
                    app = foregroundProcess.ProcessName;
                }
                return app;
            }
    
            private Process GetRealProcess(Process foregroundProcess)
            {
                WinAPIFunctions.EnumChildWindows(foregroundProcess.MainWindowHandle, ChildWindowCallback, IntPtr.Zero);
                return _realProcess;
            }
    
            private bool ChildWindowCallback(IntPtr hwnd, IntPtr lparam)
            {
                var process = Process.GetProcessById(WinAPIFunctions.GetWindowProcessId(hwnd));
                if (process.ProcessName != "ApplicationFrameHost")
                {
                    _realProcess = process;
                }
                return true;
            }
    
            public class WinAPIFunctions
            {
                //Used to get Handle for Foreground Window
                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern IntPtr GetForegroundWindow();
    
                //Used to get ID of any Window
                [DllImport("user32.dll", CharSet = CharSet.Auto)]
                private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
                public delegate bool WindowEnumProc(IntPtr hwnd, IntPtr lparam);
    
                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc callback, IntPtr lParam);
    
                public static int GetWindowProcessId(IntPtr hwnd)
                {
                    int pid;
                    GetWindowThreadProcessId(hwnd, out pid);
                    return pid;
                }
    
                public static IntPtr GetforegroundWindow()
                {
                    return GetForegroundWindow();
                }
            }
