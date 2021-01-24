      using System.Diagnostics;
      ...
      Process[] processes = Process.GetProcesses();
      foreach (Process p in processes)
      {
          if (p.MainWindowTitle == "MyFile.xlsx - Excel")
          {
              p.Kill();
              break;
          }
      }
