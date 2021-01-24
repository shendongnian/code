    Parallel.For(0, 500, new ParallelOptions(), i => {
        var process = Process.Start(
            new ProcessStartInfo(@"path\to\your\command.exe", "My Input: " + i) {
                /* more options if you like */
                RedirectStandardOutput = true,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            }
        );
        process.WaitForExit();
        string output = process.StandardOutput.ReadToEnd();
    });
