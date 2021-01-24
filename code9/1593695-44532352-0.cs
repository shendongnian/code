    public static void Log(string logEntry)
    {
        Log(logEntry, null);
    }
    
    public static void Log(string logEntry, params object[] values)
    {
       // Do whatever extra processing you need here.
       Log(String.Format(logEntry, values));
    }
