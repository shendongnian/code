                /* --- MAP THE DRIVE --- */
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
                /* WAIT FOR WINDOWS TO OPEN THE SHARE */
                System.Threading.Thread.Sleep(2000);
                /* DEMOUNT THE SHARE */
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
