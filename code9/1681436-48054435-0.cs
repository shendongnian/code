    Task[] tasks = new Task[3];
            for (int i = 0; i < 3; i++)
            {
                int x = i;
                tasks[i] = Task.Factory.StartNew(() =>
                {
                    // the processPath will be different based on whatever the value for i is
                    ProcessStartInfo startInfo = null;
                    switch (x)
                    {
                        case 0:
                            startInfo = new ProcessStartInfo("c:\\windows\\notepad.exe");
                            break;
                        case 1:
                            startInfo = new ProcessStartInfo("c:\\windows\\explorer.exe");
                            break;
                        case 2:
                            startInfo = new ProcessStartInfo("c:\\windows\\regedit.exe");
                            break;
                    }
                    Process proc = Process.Start(startInfo);
                    proc.WaitForExit();
                });
            }
            Task.WaitAll(tasks);
