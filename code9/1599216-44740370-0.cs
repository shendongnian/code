    public static void InCritical(this Mutex m, Action action)
    {
        m.WaitOne();
        try
        {
            action();
        }
        finally
        {
            m.ReleaseMutext()
        }
    }
