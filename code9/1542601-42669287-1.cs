    var processes = Process.GetProcessesByName("lmgrd")
        .Select(p => new ProcessInfo
        {
            ProcessId = p.Id,
            Name = p.MainModule.FileName
        });
    
