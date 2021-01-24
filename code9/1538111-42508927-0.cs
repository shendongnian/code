       Process[] curProcess = Process.GetProcessesByName("your youtube process name");
       Process youtubeProcess = curProcess.FirstOrDefault();  // Get here the right process instance
       while (!youtubeProcess.HasExited)
       {
           Thread.Sleep(100);
       }
    
