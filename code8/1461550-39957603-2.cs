    [SecurityCritical]
    [HandleProcessCorruptedStateExceptions]
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        
        try
        {
            var t = new Task(DoSomeAccessViolation);
            t.Start();
            t.Wait();
        }
        catch (Exception ex)
        {
            // this will NOT catch the exception
            Log(ex);
        }
    }
    [SecurityCritical]
    [HandleProcessCorruptedStateExceptions]
    private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // this will catch all unhandled exceptions, including CSEs
        Log(e.ExceptionObject as Exception);
    }
