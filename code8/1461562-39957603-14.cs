    // no need to add attributes here
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        
        // throw on a background thread
        var t = new Task(DoSomeAccessViolation);
        t.Start();
        t.Wait();
    }
    // but it's important that this method is marked
    [SecurityCritical]
    [HandleProcessCorruptedStateExceptions]
    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // this will catch all unhandled exceptions, including CSEs
        Log(e.ExceptionObject as Exception);
    }
