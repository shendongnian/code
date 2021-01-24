    var processInfo = new ProcessStartInfo("docker", $"run -it --rm blahblahblah");
    processInfo.CreateNoWindow = true;
    processInfo.UseShellExecute = false;
    processInfo.RedirectStandardOutput = true;
    processInfo.RedirectStandardError = true;
    int exitCode;
    using (var process = new Process())
    {
        process.StartInfo = processInfo;
        process.OutputDataReceived += new DataReceivedEventHandler(logOrWhatever());
        process.ErrorDataReceived += new DataReceivedEventHandler(logOrWhatever());
        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        process.WaitForExit(1200000);
        if (!process.HasExited)
        {
            process.Kill();
        }
        exitCode = process.ExitCode;
        process.Close();
    }
