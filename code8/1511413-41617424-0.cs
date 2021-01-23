    private void buildSolution(string solution, string config)
    {
        string devenv = Environment.ExpandEnvironmentVariables("\"%VS120COMNTOOLS%..\\ide\\devenv.com\"");
        string cmdArg = "\"" + solution + "\" /build " + "\"" + config + "\"";
        System.Diagnostics.Process process = new System.Diagnostics.Process();
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
        startInfo.WorkingDirectory = @"C:\";
        startInfo.FileName = devenv;
        startInfo.UseShellExecute = true;
        startInfo.Arguments = cmdArg;
        process.StartInfo = startInfo;
        process.Start();
        process.WaitForExit();
    }
