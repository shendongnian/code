    protected static bool DnsLookup(string HostName) {
        ProcessStartInfo ProcInfo = new ProcessStartInfo("cmd");
        ProcInfo.UseShellExecute = false;
        ProcInfo.RedirectStandardInput = true;
        ProcInfo.RedirectStandardOutput = true;
        ProcInfo.CreateNoWindow = true;
        bool ReturnValue;
        using (Process process__1 = Process.Start(ProcInfo)) {
            StreamWriter sw = process__1.StandardInput;
            StreamReader sr = process__1.StandardOutput;
            sw.WriteLine("nslookup -type=mx " + HostName);
            sw.Close();
            string Result = sr.ReadToEnd();
            // Parse the Result string to determine validity 
            // and set ReturnValue
        }
        return ReturnValue;
    }
