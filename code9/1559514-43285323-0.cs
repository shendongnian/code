    [DllImport("user32.dll")]
    static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    const uint WM_KEYDOWN = 0x0100;
    void SendKeyDownToProcess(string processName, System.Windows.Forms.Keys key)
    {
        Process p = Process.GetProcessesByName(processName).FirstOrDefault();
        if (p != null)
        {
            PostMessage(p.MainWindowHandle, WM_KEYDOWN, (int)key, 0);
        }
    }
