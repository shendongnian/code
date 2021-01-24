    public static bool WaitForMainWindow(this Process process)
    {
        while (!process.HasExited && process.MainWindowHandle == IntPtr.Zero)
        {
            Thread.Sleep(10);
        }
        return !process.HasExited;
    }
