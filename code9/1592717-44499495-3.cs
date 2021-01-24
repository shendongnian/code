    public static bool WaitForMainWindow(this Process process, uint timeout)
    {
        var start = DateTime.Now;
        while (!process.HasExited && process.MainWindowHandle == IntPtr.Zero)
        {
            Thread.Sleep(10);
            if ((DateTime.Now - start).TotalMilliseconds >= timeout)
            {
                return false;
            }
        }
    
        return !process.HasExited;
    }
