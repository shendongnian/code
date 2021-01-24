    private Object m_Lock = new Object();
    public static void WriteLine(string str)
    {
        lock (m_Lock)
        {
            Console.WriteLine(str);
            OutputSingleton.SW.WriteLine(str);
        }
    }
    public static void Write(string str)
    {
        lock (m_Lock)
        {
            Console.Write(str);
            OutputSingleton.SW.Write(str);
        }
    }
    private void InstantiateStreamWriter()
    {
        string logFilename = "Log.txt";
        string filePath = Path.Combine(LogDirPath, logFilename);
        try
        {
            SW = new StreamWriter(filePath);
            SW.AutoFlush = true;
        }
        catch (UnauthorizedAccessException ex)
        {
            throw new ApplicationException(string.Format("Access denied. Could not instantiate StreamWriter using path: {0}.", filePath), ex);
        }
    }
