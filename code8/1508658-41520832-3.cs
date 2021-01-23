    [return: MarshalAs(UnmanagedType.Bool)]
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    static extern bool PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
    
    // http://www.pinvoke.net/default.aspx/Enums/WindowsMessages.html
    public enum WM : uint
    {
        WM_SYSCOMMAND = 0x0112
    }
    
    // http://www.pinvoke.net/default.aspx/Enums/SysCommands.html
    enum SysCommands : int
    {
        SC_SIZE = 0xF000,
        SC_MOVE = 0xF010,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_NEXTWINDOW = 0xF040,
        SC_PREVWINDOW = 0xF050,
        SC_CLOSE = 0xF060,
        SC_VSCROLL = 0xF070,
        SC_HSCROLL = 0xF080,
        SC_MOUSEMENU = 0xF090,
        SC_KEYMENU = 0xF100,
        SC_ARRANGE = 0xF110,
        SC_RESTORE = 0xF120,
        SC_TASKLIST = 0xF130,
        SC_SCREENSAVE = 0xF140,
        SC_HOTKEY = 0xF150,
        //#if(WINVER >= 0x0400) //Win95
        SC_DEFAULT = 0xF160,
        SC_MONITORPOWER = 0xF170,
        SC_CONTEXTHELP = 0xF180,
        SC_SEPARATOR = 0xF00F,
        //#endif /* WINVER >= 0x0400 */
    
        //#if(WINVER >= 0x0600) //Vista
        SCF_ISSECURE = 0x00000001,
        //#endif /* WINVER >= 0x0600 */
    
        /*
            * Obsolete names
            */
        SC_ICON = SC_MINIMIZE,
        SC_ZOOM = SC_MAXIMIZE,
    }
