    public static List<Process> GetProcessesLockingFile(string filePath)
    {
      var procs = new List<Process>();
    
      var processListSnapshot = Process.GetProcesses();
      foreach (var process in processListSnapshot)
      {
        Console.WriteLine( process.ProcessName);
        if (process.Id <= 4) { continue; } // system processes
        var files = GetFilesLockedBy(process);
        if (files.Contains(filePath))
        {
    
          Console.WriteLine("--------------->"+process.ProcessName);
          procs.Add(process);
        }
      }
      return procs;
    }
