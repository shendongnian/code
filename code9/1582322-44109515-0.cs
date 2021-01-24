    //starts a command
    public static int RunCommandAndWait(string command, string args)
    {
        int result = -1;
        Process p = new Process();
        p.StartInfo.Arguments = args;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.FileName = command;
        p.StartInfo.UseShellExecute = true;
        if (p.Start())
        {
            p.WaitForExit();
            result = p.ExitCode;
        }
        p.Dispose();
        return result;
    }
    //kills a process using its pid and above method
    public static void KillProcessTree(int processId)
    {
        RunCommandAndWait("taskkill", String.Format("/pid {0} /f /t", processId));
        try
        {
            Process p = Process.GetProcessById(processId);
            if (p != null)
                KillProcessTree(processId); //this sometimes may be needed
        }catch(Exception)
        {
        }
    }
