    // receiver
    protected override void WndProc(ref Message msg)
    {
        if (msg.Msg == WM_COPYDATA)
        {
            if (msg.WParam == this.Handle)
            {
                CopyDataStruct copyStruct = (CopyDataStruct)Marshal.PtrToStructure(msg.LParam, typeof(CopyDataStruct));
                string messageText = Utf8PtrToString(copyStruct.lpData);
                MessageBox.Show(messageText);
            }                
        }
        base.WndProc(ref msg);
    }
    // sends text message to all other instances of itself
    private void button1_Click(object sender, EventArgs e)
    {
        Process[] myInstances = Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location));
        if (myInstances.Length == 0) return;
        foreach (Process instance in myInstances)
        {
            IntPtr handle = instance.MainWindowHandle;
            if (handle != this.Handle) SendStr(handle, "echo.. echo.. echo..");
        }
    }
    private static string Utf8PtrToString(IntPtr utf8)
    {
        int len = MultiByteToWideChar(65001, 0, utf8, -1, null, 0);
        if (len == 0) return null;
        StringBuilder sb = new StringBuilder(len);
        len = MultiByteToWideChar(65001, 0, utf8, -1, sb, len);
        return sb.ToString();
    }
    public void SendStr(IntPtr targetHandle, string msg)
    {
        int cmdLength = Encoding.UTF8.GetByteCount(msg) + 1;
        byte[] utf8cmd = new byte[cmdLength];
        Encoding.UTF8.GetBytes(msg, 0, cmdLength - 1, utf8cmd, 0);
        CopyDataStruct copyStruct = new CopyDataStruct();
        copyStruct.dwData = IntPtr.Zero;
        copyStruct.cbData = cmdLength;
        copyStruct.lpData = Marshal.AllocHGlobal(cmdLength);
        Marshal.Copy(utf8cmd, 0, copyStruct.lpData, cmdLength);
        SendMessage(targetHandle, WM_COPYDATA, targetHandle, ref copyStruct);
    }
    public static uint WM_COPYDATA = 0x004A;
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref CopyDataStruct lParam);
    [DllImport("user32.dll")]
    static extern uint RegisterWindowMessage(string lpString);
    [StructLayout(LayoutKind.Sequential)]
    public struct CopyDataStruct
    {
        public IntPtr dwData;
        public int cbData;
        public IntPtr lpData;
    }
    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int MultiByteToWideChar(int codepage, int flags, IntPtr utf8, int utf8len, StringBuilder buffer, int buflen);
