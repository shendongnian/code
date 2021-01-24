    Console.Out.WriteLine("Current ProcessID: " + Process.GetCurrentProcess().Id); //This prints the process id
    Console.Out.WriteLine("Waiting for debugger to attach...");
    while (!Debugger.IsAttached)
    {
        Thread.Sleep(100);
    }
    Console.Out.WriteLine("Debugger attached!");
