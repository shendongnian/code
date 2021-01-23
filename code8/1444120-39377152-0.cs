    private int counter = 0;
        int sumOfImages = 10; // Set this to the number of files
        private void ProcessStart(List<string> files)
        {
            foreach (string file in files)
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "someCommand";
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.Exited += Process_Exited;
                process.Start();
            }
        }
        private void Process_Exited(object sender, EventArgs e)
        {
            int result = Interlocked.Increment(ref counter);
            int percentComplete = ((result / sumOfImages) * 100);
            worker.ReportProgress(percentComplete);
        }
