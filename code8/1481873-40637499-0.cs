    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = String.Format(@"sc create \"servicename\" \"{0}\"", filepath);
    startInfo.Verb = "runas";
    process.StartInfo = startInfo;
    process.Start();
