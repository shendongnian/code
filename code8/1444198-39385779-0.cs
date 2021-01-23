    static void Main()
    {
        JobHostConfiguration config = new JobHostConfiguration();
        // Add Triggers and Binders for Timer Trigger.
        config.UseTimers();
        JobHost host = new JobHost(config);
        //host.RunAndBlock();
        host.Start();
        Console.WriteLine("[{0}] Job Host started!!!", DateTime.Now);
        Console.ReadLine();
    }
