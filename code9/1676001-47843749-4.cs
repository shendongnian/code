    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;
    ProcessStartInfo psInfo = new ProcessStartInfo() {
        UseShellExecute = true,
        FileName = "rundll32.exe",
        Arguments = "shell32.dll, Control_RunDLL timedate.cpl,,0", //<- 0 = First Tab
        WindowStyle = ProcessWindowStyle.Normal
    };
    Process sysClockProcess = new Process() {
        SynchronizingObject = this,
        EnableRaisingEvents = true,
        StartInfo = psInfo
    };
    sysClockProcess.Start();
    sysClockProcess.WaitForInputIdle();
    //Insert the Window title. It's case SENSITIVE
    //Window Title in HKEY_CURRENT_USER\Software\Classes\Local Settings\MuiCache\[COD]\[LANG]\
    string windowTitle = "Date and Time";
    int maxLenght = 256;
    SetWindowPosFlags flags = SetWindowPosFlags.NoSize |
                              SetWindowPosFlags.AsyncWindowPos |
                              SetWindowPosFlags.ShowWindow;
    //The first thread is the Main thread. All Dialog windows' handles are attached here.
    //The second thread is for GDI+ Hook Window. Ignore it.
    EnumThreadWindows((uint)sysClockProcess.Threads[0].Id, (hWnd, lParam) =>
    {
        StringBuilder lpString = new StringBuilder(maxLenght);
        if (GetWindowText(hWnd, lpString, maxLenght) > 0)
            if (lpString.ToString() == windowTitle)
            {
                GetWindowRect(hWnd, out RECT lpRect);
                Size size = new Size(lpRect.Right - lpRect.Left, lpRect.Bottom - lpRect.Top);
                //Caculate the position of the Clock Windows relative to the ref. Form Size
                SetWindowPos(hWnd, (IntPtr)0, ((this.Width + this.Left) - size.Width),
                                              ((this.Height + this.Top) - size.Height), 0, 0, flags);
                return false;
            }
        //Window not found: return true to continue the enumeration
        return true;
    }, ref windowTitle);
    sysClockProcess.Exited += (s, ev) => {
        Console.WriteLine($"The process has exited. Code: " +
            $"{sysClockProcess.ExitCode} Time: {sysClockProcess.ExitTime}");
        sysClockProcess.Dispose();
    };
