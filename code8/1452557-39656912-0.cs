    [DllImport("User32", CharSet = CharSet.Auto)]
    public static extern int ShowWindow(IntPtr hWnd, int cmdShow);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsIconic(IntPtr hwnd);
    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hWnd);
    private void send_Click(object sender, EventArgs e)
    {
        var notepad = Process.GetProcessesByName("Notepad").FirstOrDefault(p => p.MainWindowTitle == "Untitled - Notepad");
        if (notepad != null)
        {
            if (IsIconic(notepad.MainWindowHandle))
                ShowWindow(notepad.MainWindowHandle, 9);
            SetForegroundWindow(notepad.MainWindowHandle);
            Clipboard.SetText("Here's some text to paste into the Notepad window");
            SendKeys.Send("^V");
        }
    }
