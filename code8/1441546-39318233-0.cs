    Process proc = new Process();
    proc.StartInfo.FileName = @"console.exe";
    proc.StartInfo.Arguments = "My args";
    proc.StartInfo.CreateNoWindow = false;
    proc.StartInfo.RedirectStandardError = true;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
    //store outcome of process
    var errors = new StringBuilder();
    var output = new StringBuilder();
    var hadErrors = false;
    // raise events
    proc.EnableRaisingEvents = true;
    // capture normal output
    proc.OutputDataReceived += (s, d) => { 
        output.Append(d.Data); 
    };
    // Capture error output
    proc.ErrorDataReceived += (s, d) => { 
        if (!hadErrors)
        {
            hadErrors = !String.IsNullOrEmpty(d.Data);
        }
        errors.Append(d.Data); 
    };
    proc.Start();
    // start listening on the stream
    proc.BeginErrorReadLine();
    proc.BeginOutputReadLine();
    proc.WaitForExit();
    string stdout = output.ToString();
    string stderr = errors.ToString();
    if (proc.ExitCode !=0 || hadErrors)
    {
        MessageBox.Show("error:" + stderr);
    }
