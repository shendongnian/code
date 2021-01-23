    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
    ...
    [HandleProcessCorruptedStateExceptions, SecurityCritical]
    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // AccessViolationExceptions will get caught here but you cannot stop
        // the termination of the process if e.IsTerminating is true.
    }
