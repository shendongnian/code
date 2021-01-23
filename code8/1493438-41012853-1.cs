            public static void ReleaseOlderFiles()
        {
            string[] files = Directory.GetFiles(scherm1);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddMilliseconds(-5000))
                {
                    try
                    {
                        Process[] runningProcs = Process.GetProcesses();
                        foreach (Process proc in runningProcs)
                        {
                            foreach (int pid in pids)
                            {
                                if (pid == proc.Id)
                                {
                                    TryKillProcessByMainWindowHwnd(pid);
                                }
                            }
                        }
                    }
                    catch { }
                    Thread.Sleep(500);
                    fi.Delete();
                }
            }
        }
