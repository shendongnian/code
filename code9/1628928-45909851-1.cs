     System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new 
        System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.FileName = "cmd.exe";
        startInfo.Arguments = "/C ipconfig /flushdns";
        startInfo.Verb = "runas";
        process.StartInfo = startInfo;
        process.Start();
    
    System.Diagnostics.Process process2 = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo2 = new 
        System.Diagnostics.ProcessStartInfo();
        startInfo2.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo2.FileName = "cmd.exe";
        startInfo2.Arguments = "/C ipconfig /renew";
        startInfo2.Verb = "runas";
        process2.StartInfo = startInfo2;
        process2.Start();
