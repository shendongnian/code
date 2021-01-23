    public static float ProcessorUtilization;
    
    public static float GetAverageCPU()
    {
        PerformanceCounter cpuCounter = new PerformanceCounter("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
        for (int i = 0; i < 11; ++i)
        {
            ProcessorUtilization += (cpuCounter.NextValue() / Environment.ProcessorCount);
        }
        // Remember the first value is 0, so we don't want to average that in.
        Console.Writeline(ProcessorUtilization / 10); 
        return ProcessorUtilization / 10;
    }
