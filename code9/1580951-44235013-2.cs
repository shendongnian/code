    Log("Test 1", "General");
    Log("Test 2", "General");
    static bool HasLogWriterBeenDisposed()
    {
        var fieldInfo = typeof(Logger).GetField("writer", BindingFlags.NonPublic | BindingFlags.Static);       
        return fieldInfo?.GetValue(null) == null;
    }
    static void Log(string message, string category)
    {
        if (HasLogWriterBeenDisposed())
        {
            InitializeLogger();
        }
        // Write message
        Logger.Write(message, category);
        // Dispose and set the logger to the null
        Logger.Reset();
    }
    static void InitializeLogger()
    {
        IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
        LogWriterFactory logWriterFactory = new LogWriterFactory(configurationSource);
        Logger.SetLogWriter(logWriterFactory.Create(), false);
    }
