    /// <summary>
    /// Sets foreground window
    /// </summary>
    /// <param name="hWnd"></param>
    /// <returns></returns>
    [DllImport("user32.dll")]
    internal static extern bool SetForegroundWindow(IntPtr hWnd);
