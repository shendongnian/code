                PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                float tempValue = cpuCounter.NextValue();
                Thread.Sleep(1000);
                Console.WriteLine(cpuCounter.NextValue());
            }
    
