    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);
    public static IntPtr getThreadWindowHandle(uint dwThreadId)
    {
        IntPtr hWnd;
        // Get Window Handle and title from Thread
        var guiThreadInfo = new GUITHREADINFO();
        guiThreadInfo.cbSize = Marshal.SizeOf(guiThreadInfo);
        GetGUIThreadInfo(dwThreadId, ref guiThreadInfo);
        hWnd = guiThreadInfo.hwndFocus;
        //some times while changing the focus between different windows, it returns Zero so we would return the Active window in that case
        if (hWnd == IntPtr.Zero)
        {
            hWnd = guiThreadInfo.hwndActive;
        }
        return hWnd;
    }
    [DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
    public static extern int GetWindowThreadProcessId(IntPtr windowHandle, out int processId);
    static void Main(string[] args)
    {
        var current = getThreadWindowHandle(0);
        int processId = 0;
        GetWindowThreadProcessId(current, out processId);
        var foregroundProcess = GetActiveProcess(processId);
    }
    private static Process GetActiveProcess(int activeWindowProcessId)
    {
        Process foregroundProcess = null;
        try
        {
            foregroundProcess = Process.GetProcessById(activeWindowProcessId);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        if (string.IsNullOrWhiteSpace(GetProcessNameSafe(foregroundProcess)))
        {
            var msg = "Process name is empty.";
            Console.WriteLine(msg);
        }
        return foregroundProcess;
    }
