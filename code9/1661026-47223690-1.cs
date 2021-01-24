    //Determines if it's a network share or not.
    if (appToRun.DependentPC.Contains(@"\"))
    {
        var startTime = DateTime.Now;
        var directoryInfo = new DirectoryInfo(appToRun.DependentPC);
    
        //wait until directory exists or timeout reached.
        while (DateTime.Now - startTime < TimeSpan.FromSeconds(Convert.ToInt32(DependentPCTimeout)) && !directoryInfo.Exists) { }
        if (!directoryInfo.Exists)
        {
            XtraMessageBox.Show($"Could not find or get a reply from the computer share '{appToRun.DependentPC}'. ", $"{appToRun.DependentPC} Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }
    else
    {
        //Ping computer.
        if (PingComputer(appToRun.DependentPC) != IPStatus.Success)
        {
            XtraMessageBox.Show($"Could not find or get a reply from the computer '{appToRun.DependentPC}'. ", $"{appToRun.DependentPC} Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }
    }
