    public class WindowMinimize
    {
        const int SW_SHOWMINNOACTIVE = 7;
        // Hide other windows
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static void MinimizeWindow(IntPtr handle)
        {
            ShowWindow(handle, SW_SHOWMINNOACTIVE);
        }
        public static void MinimizeAll()
        {
            System.Diagnostics.Process thisProcess =
               System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] processes =
               System.Diagnostics.Process.GetProcesses();
            try
            {
                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process == thisProcess) continue;
                    System.IntPtr handle = process.MainWindowHandle;
                    if (handle == System.IntPtr.Zero) continue;
                    MinimizeWindow(handle);
                } //loop
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        } 
    }
