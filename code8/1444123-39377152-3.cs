    private void ProcessStart(List<string> files)
        {
            int sumOfImages = files.Count;
            int count = 0;
            string command = "";
            Parallel.ForEach(files,
                delegate (string file)
                {
                    Process process = new Process();
                    process.StartInfo.UseShellExecute = false;
                    // You can start any process, HelloWorld is a do-nothing example.
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.Arguments = command;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    process.WaitForExit();
                    int result = Interlocked.Increment(ref count);
                    int percentComplete = ((result / sumOfImages) * 100);
                    worker.ReportProgress(percentComplete);
                });
        }
