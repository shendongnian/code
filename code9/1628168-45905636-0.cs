    var sb = new StringBuilder();
    bool capture = false;
    
    var proc = new Process();
    // we run cms on our own
    proc.StartInfo.FileName = "cmd";
    // we want to capture and control output and input
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.RedirectStandardOutput = true;
    proc.StartInfo.RedirectStandardInput = true;
    
    // get all output from the commandline
    proc.OutputDataReceived += (s, e) => { if (capture) sb.AppendLine(e.Data); };
    
    // start
    proc.Start();
    proc.BeginOutputReadLine(); // will start raising the OutputDataReceived
             
    proc.StandardInput.WriteLine(@"cd \tmp"); // where is the cmd file
    System.Threading.Thread.Sleep(1000); // give it a second
    proc.StandardInput.WriteLine(@"setenv.cmd"); // run the cmd file
    System.Threading.Thread.Sleep(1000); // give it a second
    
    capture = true; // what comes next is of our interest
    proc.StandardInput.WriteLine(@"set"); // this will list all environmentvars for that process
    System.Threading.Thread.Sleep(1000); // give it a second
    proc.StandardInput.WriteLine(@"exit"); // done
    proc.WaitForExit();
    
    // parse our result, line by line
    var sr = new StringReader(sb.ToString());
    string line = sr.ReadLine();
    while (line != null)
    {
        var firstEquals = line.IndexOf('=');
        if (firstEquals > -1)
        {
            // until the first = will be the name
            var envname = line.Substring(0, firstEquals);
            // rest is the value
            var envvalue = line.Substring(firstEquals+1);
            // capture what is of interest
            if (envname.StartsWith("test"))
            {
                Environment.SetEnvironmentVariable(envname, envvalue);
            }
        }
        line = sr.ReadLine();
    }
    Console.WriteLine(Environment.GetEnvironmentVariable("test2")); // will print > bar
