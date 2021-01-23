    var proc = new Process {
        StartInfo = new ProcessStartInfo {
            FileName = "xcopy",
            Arguments = "source1 dest1",
            RedirectStandardOutput = true
        }
    };
    proc.Start();
    string response=string.Empty;
    while (!proc.StandardOutput.EndOfStream) {
        response += proc.StandardOutput.ReadLine();
    }
