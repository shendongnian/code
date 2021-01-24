    static void Main()
    {
        SendMessage(GetDesktopWindow(DesktopWindow.SysListView32), LVM_ARRANGE, LVA_SNAPTOGRID, 0);
        Console.ReadLine();
    }
    public const int LVM_ARRANGE = 4118;
    public const int LVA_SNAPTOGRID = 5;
    [DllImport("user32.dll")]
    static extern IntPtr GetShellWindow();
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);
    [DllImport("User32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetDesktopWindow();
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowTextLength(IntPtr hWnd);
    public enum DesktopWindow
    {
        ProgMan,
        SHELLDLL_DefViewParent,
        SHELLDLL_DefView,
        SysListView32
    }
    public static IntPtr GetDesktopWindow(DesktopWindow desktopWindow)
    {
        IntPtr _ProgMan = GetShellWindow();
        IntPtr _SHELLDLL_DefViewParent = _ProgMan;
        IntPtr _SHELLDLL_DefView = FindWindowEx(_ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
        IntPtr _SysListView32 = FindWindowEx(_SHELLDLL_DefView, IntPtr.Zero, "SysListView32", "FolderView");
        if (_SHELLDLL_DefView == IntPtr.Zero)
        {
            EnumWindows((hwnd, lParam) =>
            {
                if (GetWindowText(hwnd) == "WorkerW")
                {
                    IntPtr child = FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                    if (child != IntPtr.Zero)
                    {
                        _SHELLDLL_DefViewParent = hwnd;
                        _SHELLDLL_DefView = child;
                        _SysListView32 = FindWindowEx(child, IntPtr.Zero, "SysListView32", "FolderView"); ;
                        return false;
                    }
                }
                return true;
            }, IntPtr.Zero);
        }
        switch (desktopWindow)
        {
            case DesktopWindow.ProgMan:
                return _ProgMan;
            case DesktopWindow.SHELLDLL_DefViewParent:
                return _SHELLDLL_DefViewParent;
            case DesktopWindow.SHELLDLL_DefView:
                return _SHELLDLL_DefView;
            case DesktopWindow.SysListView32:
                return _SysListView32;
            default:
                return IntPtr.Zero;
        }
    }
    public static string GetWindowText(IntPtr hWnd)
    {
        int size = GetWindowTextLength(hWnd);
        if (size > 0)
        {
            var builder = new StringBuilder(size + 1);
            GetWindowText(hWnd, builder, builder.Capacity);
            return builder.ToString();
        }
        return String.Empty;
    }
