    [SecurityCritical]
    [HandleProcessCorruptedStateExceptions]
    static void Main(string[] args)
    {
        try
        {
            DoSomeAccessViolation();
        }
        catch (Exception ex)
        {
            // this will catch all CSEs in the main thread
            Log(ex);
        }
    }
