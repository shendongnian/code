    Log("Test 1", "General");            
    Log("Test 2", "General");            
    static void Log(string message, string category)
    {
        bool isLogWriterDisposed = false;
        try
        {
            // If Writer is null InvalidOperation will be thrown
            var logWriter = Logger.Writer;
        }
        catch (InvalidOperationException e)
        {
            isLogWriterDisposed = true;
        }
        if (isLogWriterDisposed)
        {
            InitializeLogger();
        }
        // Write message
        Logger.Write(message, category);
        // Dispose the existing LogWriter and set it to null
        Logger.Reset();
    }
