    public static void ExecProcess(string name, string args)
    {
        Process p = new Process();
        p.StartInfo.FileName = name;
        p.StartInfo.Arguments = args;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;
        p.Start();
        string log = p.StandardOutput.ReadToEnd();
        string errorLog = p.StandardError.ReadToEnd();
        p.WaitForExit();
        p.Close();
    }
