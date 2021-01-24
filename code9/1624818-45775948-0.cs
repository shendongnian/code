    var psi = new ProcessStartInfo("dotnet", "--version")
    {
        RedirectStandardOutput = true
    };
    var process = Process.Start(psi);
    process.WaitForExit();
    Console.Write(process.StandardOutput.ReadToEnd()); // writes 2.0.0
    
