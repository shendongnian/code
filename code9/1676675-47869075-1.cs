    System.Diagnostics.Process process = new System.Diagnostics.Process();
    // process.StartInfo.UseShellExecute = false;
    // process.StartInfo.RedirectStandardOutput = true;
    // process.StartInfo.RedirectStandardError = true;
    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.FileName = "c:\\windows\\system32\\osk.exe";
    process.StartInfo.Arguments = "";
    process.StartInfo.WorkingDirectory = "c:\\";
    
    process.Start(); // **ERROR WAS HERE**
    //process.WaitForInputIdle();
    //Wait for handle to become available
    while(process.MainWindowHandle == IntPtr.Zero)
        Task.Delay(10).Wait();
    SetWindowPos(process.MainWindowHandle,
    this.Handle, // Parent Window
    this.Left, // Keypad Position X
    this.Top + 20, // Keypad Position Y
    panelButtons.Width, // Keypad Width
    panelButtons.Height, // Keypad Height
    SWP_SHOWWINDOW | SWP_NOZORDER); // Show Window and Place on Top
    SetForegroundWindow(process.MainWindowHandle);
