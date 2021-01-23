        private string execute(string command, string arguments, int mstimeout)
        {
            bool timeout = false;
            string report = string.Empty;
            StringBuilder output = new StringBuilder();
            StringBuilder error = new StringBuilder();
            Process p = new Process();
            DataReceivedEventHandler StoreError = (o, e) => { error.Append(e.Data); };
            DataReceivedEventHandler StoreOutput = (o, e) => { output.Append(e.Data); };
            try
            {
                Debug.WriteLine(command);
                Debug.WriteLine(arguments);
                p.StartInfo.FileName = command;
                p.StartInfo.Arguments = arguments;
                p.EnableRaisingEvents = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.OutputDataReceived += StoreOutput;
                p.ErrorDataReceived += StoreError;
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                if (!p.WaitForExit(mstimeout))
                {
                    p.Kill();
                    timeout = true;
                    Debug.WriteLine("Process killed");
                }
                else
                {
                    p.WaitForExit();
                }
            }
            finally
            {
                report = output.ToString() + "\n" + error.ToString();
                Debug.WriteLine(report);
                p.Dispose();
            }
            if (timeout)
            {
                throw new TimeoutException("Timeout during call: " + command + " " + arguments);
            }
            return report;
        }
