    List<Process> procs = Process.GetProcesses();
    Process steam = procs.Find(x => x.ProcessName == "Steam");
    int steamId = steam.Id;
    foreach (var proc in procs)
    {
        using (ManagementObject mo = new ManagementObject($"win32_process.handle='{proc.Id}'"))
        {
            if (mo != null)
            {
                try
                {
                    mo.Get();
                    int parentPid = Convert.ToInt32(mo["ParentProcessId"]);
                    if (parentPid == steamId)
                    {
                        Console.WriteLine($"{proc.ProcessName} is running as a child to {mo["ParentProcessId"]}");
                    }
                }
                catch (Exception ex)
                {
                    // the process ended between polling all of the procs and requesting the management object
                }
            }
        }
    }
