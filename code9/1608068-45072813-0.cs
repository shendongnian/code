using System.Diagnostics;
    Process[] processes = Process.GetProcesses();
    List<string> namesOfRunningProcesses = new List<string>();
    foreach(Process p in processes)
     namesOfRunningProcesses.Add(p.ProcessName);
