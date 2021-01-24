    string adbPath = @"G:\Android\android-sdk\platform-tools\adb.exe";
    ProcessStartInfo startInfo = new ProcessStartInfo(adbPath, "logcat MyApp_LoggingTag:V AndroidRuntime:E *:S");
    startInfo.CreateNoWindow = true;
    startInfo.UseShellExecute = false;
    startInfo.RedirectStandardOutput = true;           
    // if you don't want to recreate it each time - choose another file mode, like FileMode.Append
    using (var fs = new FileStream(@"C:\logcat.txt", FileMode.Create, FileAccess.Write, FileShare.Read)) {
        using (var writer = new StreamWriter(fs)) {                    
            Process logcatRunner = new Process();
            logcatRunner.StartInfo = startInfo;
            logcatRunner.EnableRaisingEvents = true;
            logcatRunner.OutputDataReceived += (sender, args) => {
                // Data null indicates end of output stream - don't write it
                if (args.Data != null) {
                    writer.Write(args.Data);
                    // flush immediately if needed
                    writer.Flush();
                }
            };
            logcatRunner.Start();
            logcatRunner.BeginOutputReadLine();
            Console.WriteLine("Logging started, press any key to stop");
            Console.ReadKey();
            logcatRunner.CancelOutputRead();
            logcatRunner.Kill();
            logcatRunner.WaitForExit();
        }
    }
