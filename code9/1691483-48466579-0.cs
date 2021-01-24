        static void OnTime(object sender, ElapsedEventArgs e)
        {
                timer.Stop();
                
                try {
                    var procs = from a in Process.GetProcesses()
                                where a.ProcessName == procName
                                select a;
                    foreach (Process proc in procs) {
                        ProcessTask(proc.MainWindowHandle);
                    }
                }
                finally { timer.Start(); }
        }
