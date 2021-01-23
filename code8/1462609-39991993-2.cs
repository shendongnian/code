    private void bwRezerve_DoWork(object sender, DoWorkEventArgs e)
    {
        ProcessStartInfo psi = new ProcessStartInfo();
        psi.FileName = Application.StartupPath + Path.DirectorySeparatorChar + "7z.exe";
        psi.Arguments = e.Argument;
        psi.UseShellExecute = false;
        psi.RedirectStandardError = true;
        psi.RedirectStandardOutput = true;
        psi.CreateNoWindow = true;
    
        Process proc = Process.Start(psi);
        proc.WaitForExit();
    
        while (!proc.StandardOutput.EndOfStream)
        {
           string line = proc.StandardOutput.ReadLine();
           AddTextToTextbox(line);
        }
    }
