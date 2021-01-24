        uint ClipBoadrOwnerThreadId = 0;
        uint ClipBoadrOwnerProcessId = WinApi.GetClipboardOwnerProcessID(ref ClipBoadrOwnerThreadId);
        Process ClipBoardOwnerProcess = Process.GetProcessById((int)ClipBoadrOwnerProcessId);
        
        string ProcessName = ClipBoardOwnerProcess.ProcessName;
        string ProcessWindowTitle = ClipBoardOwnerProcess.MainWindowTitle;
        string ProcessFileName = ClipBoardOwnerProcess.MainModule.FileName;
        //(...)
