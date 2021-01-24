    delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
    [DllImport("user32.dll")]
    private static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumWindowsProc ewp, int lParam);
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern bool GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    [DllImport("user32.dll")]
    private static extern uint GetWindowText(IntPtr hWnd, StringBuilder lpString, uint nMaxCount);
    [DllImport("user32.dll")]
    private static extern uint GetWindowTextLength(IntPtr hWnd);
    [DllImport("user32.dll")]
    static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    // get all the process id's of the running chrome processes
    Process[] chromeProcesses = Process.GetProcessesByName("chrome");
    List<uint> chromeProcessIds = chromeProcesses.Select(x => (unit)x.Id).ToList();
    
    // a list to store the handles of the Google Chrome windows that we'll find
    List<IntPtr> windowHandles = new List<IntPtr>();
    EnumWindowsProc enumerateHandle = delegate (IntPtr hWnd, int lParam)
    {
        // get the id of the process of the window we are enumerating over
        uint id;
        GetWindowThreadProcessId(hWnd, out id);
        // if the process we're enumerating over has an id in our chrome process ids, we need to inspect it to see if it is a window or other process
        if (chromeProcessIds.Contains(id))
        {
            // get the name of the class of the window we are inspecting
            var clsName = new StringBuilder(256);
            var hasClass = GetClassName(hWnd, clsName, 256);
            if (hasClass)
            {
                // get the text of the window we are inspecting
                var maxLength = (int)GetWindowTextLength(hWnd);
                var builder = new StringBuilder(maxLength + 1);
                GetWindowText(hWnd, builder, (uint)builder.Capacity);
                var text = builder.ToString();
                var className = clsName.ToString();
                // actual Google Chrome windows have text set to the title of the active tab
                // in my testing, this needs to be coupled with the class name equaling "Chrome_WidgetWin_1". 
                // i haven't tested this with other versions of Google Chrome
                if (!string.IsNullOrWhiteSpace(text) && className.Equals("Chrome_WidgetWin_1", StringComparison.OrdinalIgnoreCase))
                {
                    // if we satisfy the conditions, this is a Google Chrome window. Add the handle to the list of handles to use later.
                    windowHandles.Add(hWnd);
                }
            }
        }
        return true;
    };
    EnumDesktopWindows(IntPtr.Zero, enumerateHandle, 0);
    foreach (IntPtr ptr in windowHandles)
    {
        AutomationElement root = AutomationElement.FromHandle(ptr);
       
        // continue grabbing Chrome tab information using the AutomationElement method
        ...
    }
