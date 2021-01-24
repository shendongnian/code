    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    process.StartInfo = startInfo;
    startInfo.FileName = "cmd.exe";
    startInfo.Arguments = "/C notepad";
    process.Start();
    startInfo.Arguments = "/C {Insert the full path to Excel exe}excel";
    process.Start();
