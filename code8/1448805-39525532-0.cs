    new Thread(() =>
    {
        var cpu = new PerformanceCounter
        {
            CategoryName = "Processor",
            CounterName = "% Processor Time",
            InstanceName = "_Total"
        }
        while (true)
        {
            Debug.WriteLine("{0:0.0}%", cpu.NextValue());
            Thread.Sleep(1000);
        }
    }).Start();
