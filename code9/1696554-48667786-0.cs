    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(); 
     startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
     startInfo.FileName = "test.exe";
     process.StartInfo = startInfo;
     process.Start();
     process.WaitForExit(); // this will block while the process is running
