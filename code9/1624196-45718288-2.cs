    System.Diagnostics.ProcessStartInfo startInfo = new ProcessStartInfo();
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    process.StartInfo = startInfo;
    startInfo.FileName = "notepad";
    process.Start();
    startInfo.FileName = "excel";
    process.Start();
