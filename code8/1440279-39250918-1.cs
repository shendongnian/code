    [DllImport("kernel32.dll", SetLastError=true)]
    public static extern IntPtr GetConsoleWindow();
    [DllImport("kernel32.dll", SetLastError=true)]
    public static extern bool GetConsoleMode(
        IntPtr hConsoleHandle,
        ref int lpMode);
    [DllImport("kernel32.dll", SetLastError=true)]
    public static extern bool SetConsoleMode(
        IntPtr hConsoleHandle,
        int ioMode);
    /// <summary>
    /// This flag enables the user to use the mouse to select and edit text. To enable
    /// this option, you must also set the ExtendedFlags flag.
    /// </summary>
    const int QuickEditMode = 64;
    // ExtendedFlags must be combined with
    // InsertMode and QuickEditMode when setting
    /// <summary>
    /// ExtendedFlags must be enabled in order to enable InsertMode or QuickEditMode.
    /// </summary>
    const int ExtendedFlags = 128;
    void DisableQuickEdit()
    {
        IntPtr conHandle = GetConsoleWindow();
        int mode;
        if (!GetConsoleMode(conHandle, ref mode))
        {
            // error getting the console mode. Exit.
            return;
        }
        mode = mode & ~(QuickEditMode | ExtendedFlags);
        if (!SetConsoleMode(conHandle, mode))
        {
            // error setting console mode.
        }
    }
    void EnableQuickEdit()
    {
        IntPtr conHandle = GetConsoleWindow();
        int mode;
        if (!GetConsoleMode(conHandle, ref mode))
        {
            // error getting the console mode. Exit.
            return;
        }
        mode = mode | (QuickEditMode | ExtendedFlags);
        if (!SetConsoleMode(conHandle, mode))
        {
            // error setting console mode.
        }
    }
