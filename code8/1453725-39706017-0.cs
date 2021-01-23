    using System.Diagnostics;
    using System.Runtime.InteropServices;
<!---->
    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
        string lpszClass, string lpszWindow);
    [DllImport("User32.dll")]
    static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, string lParam);
    const int WM_SETTEXT = 0x000C;
    private void button1_Click(object sender, EventArgs e)
    {
        //Find notepad by its name, or use the instance which you opened yourself
        var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
        if(notepad!=null)
        {
            var edit = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);
            SendMessage(edit, WM_SETTEXT, IntPtr.Zero, "This is a Text!");
        }
    }
