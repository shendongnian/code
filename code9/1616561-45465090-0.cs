                Process netuseP = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "net.exe",
                        Arguments = $"use {uncPath} /u:{username} {password}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                    }
                };
                netuseP.Start();
                /* --- OPEN THE UNC PATH --- */
                Process azureP = new Process
                {
                    StartInfo = {
                        FileName = "explorer.exe",
                        Arguments = uncPath,
                        UseShellExecute = false,
                    },
                    EnableRaisingEvents = true,
                };
                azureP.Start();
                /* --- WAIT FOR THE PATH TO BE OPENED --- */
                azureP.Exited += ((object proc, EventArgs procE) =>
                {
                    /* --- GET THE EXPLORER.EXE PROCESS THAT IS RELATED TO THE AZURE STORAGE ACCOUNT --- */
                    Process[] currentExplorers = Process.GetProcessesByName("explorer");
                    Process explorerP = null;
                    foreach (Process p in currentExplorers)
                    {
                        if (azureP.StartTime < p.StartTime)
                        {
                            explorerP = p;
                        }
                    }
                    if (explorerP != null)
                    {
                        explorerP.Exited += ((object eProc, EventArgs eProcE) =>
                        {
                            /* --- DEMOUNT THE FILE SHARE --- */
                            netuseP = new Process
                            {
                                StartInfo = new ProcessStartInfo
                                {
                                    FileName = "net.exe",
                                    Arguments = $"use {uncPath} /delete",
                                    RedirectStandardOutput = true,
                                    RedirectStandardError = true,
                                    UseShellExecute = false,
                                }
                            };
                            netuseP.Start();
                        });
                    }
                });
