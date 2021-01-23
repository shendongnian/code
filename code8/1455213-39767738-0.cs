    using System.ComponentModel;
    using System.Windows.Forms;
    ...
    
    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetMessage(out Message lpMsg, IntPtr hwnd, int wMsgFilterMin, int wMsgFilterMax);
    [DllImport("user32.dll")]
    static extern int TranslateMessage(Message lpMsg);
    [DllImport("user32.dll")]
    static extern int DispatchMessage(Message lpMsg);
