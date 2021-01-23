    ProcessStartInfo psi = new ProcessStartInfo();            
    psi.FileName = "netsh";            
    psi.UseShellExecute = false;
    psi.RedirectStandardError = true;
    psi.RedirectStandardOutput = true;
    psi.Arguments = "SOME_ARGUMENTS";
                
    Process proc = Process.Start(psi);                
    proc.WaitForExit();
    string errorOutput = proc.StandardError.ReadToEnd();
    string standardOutput = proc.StandardOutput.ReadToEnd();
    if (proc.ExitCode != 0)
        throw new Exception("netsh exit code: " + proc.ExitCode.ToString() + " " + (!string.IsNullOrEmpty(errorOutput) ? " " + errorOutput : "") + " " + (!string.IsNullOrEmpty(standardOutput) ? " " + standardOutput : ""));
