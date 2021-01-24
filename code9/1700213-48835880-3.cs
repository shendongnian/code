    Process ClipBoardOwnerProcess = Process.GetProcessById((int)WinApi.GetClipboardOwnerProcessID());
        
    string ProcessName = ClipBoardOwnerProcess.ProcessName;
    string ProcessWindowTitle = ClipBoardOwnerProcess.MainWindowTitle;
    string ProcessFileName = ClipBoardOwnerProcess.MainModule.FileName;
    //(...)
