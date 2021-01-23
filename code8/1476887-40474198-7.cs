    const string mutexId = "MyProg";
    MutexAccessRule allowEveryoneRule =
        new MutexAccessRule(
            new SecurityIdentifier(WellKnownSidType.WorldSid, null),
            MutexRights.FullControl, AccessControlType.Allow);
    MutexSecurity securitySettings = new MutexSecurity();
    securitySettings.AddAccessRule(allowEveryoneRule);
    Mutex globalMutex = null;
    try
    {
        bool createdNew;
        globalMutex = new Mutex(false, "Global\\" + mutexId, out createdNew, securitySettings);
    }
    catch (UnauthorizedAccessException)
    {
        // Ignore
    }
    Mutex localMutex = new Mutex(false, mutexId);
    try
    {
        // Run your program here
    }
    finally
    { 
        // These have to be called only after the application (its windows) closes.
        // You can also remove these calls and let the system release the mutexes.
        if (globalMutex != null)
        {
            globalMutex.Dispose();
        }
        localMutex.Dispose();
    }
