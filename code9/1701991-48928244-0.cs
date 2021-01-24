            var processName = Process.GetCurrentProcess().ProcessName;
            PerformanceCounter ramCounter = new PerformanceCounter("Process", "Working Set - Private", processName);
            PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", processName);
            
            while (true)
            {
                double ram = ramCounter.NextValue();
                double cpu = cpuCounter.NextValue() / Environment.ProcessorCount;
                Console.Clear();
                Console.WriteLine("RAM: "
                                  + (ram / 1024).ToString("N0") + " KB; CPU: "
                                  + cpu.ToString("N1") + " %;");
                Thread.Sleep(500);
            }
