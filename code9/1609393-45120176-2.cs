    try
    {
        foreach (Process proc in Process.GetProcessesByName("cmd"))
        {
            proc.Kill();
        }
        foreach (Process proc in Process.GetProcessesByName("taskmgr"))
        {
            proc.Kill();
        }
    }
    catch(Exception ex)
    {
        Console.log($"Some error occured while trying to kill cmds and task managers: ${ex}")
    }
