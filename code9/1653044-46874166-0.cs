    static void DisplayProcesses()
            {
                var processes = new List<ProcessData>();
                foreach (var process in Process.GetProcesses())
                {
                    if (process.WorkingSet64 >= 20 * 1021 * 1021;)
                    {
                        processes.Add(new ProcessData
                        {
                            Id = process.Id,
                            Name = process.ProcessName,
                            Memory = process.WorkingSet64
                        });
                    }
                }
                Console.WriteLine();
            }
