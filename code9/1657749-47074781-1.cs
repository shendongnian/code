    ProcessStartInfo processInfo = new ProcessStartInfo
    {
        FileName = "console_program",
        CreateNoWindow = true,
        UseShellExecute = false,
        RedirectStandardOutput = true,
        RedirectStandardInput = true,
    };
    Process process = new Process
    {
        StartInfo = processInfo,
    };
    process.Start();
    process.StandardInput.WriteLine("Hey!");
    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();
