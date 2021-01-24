    private static readonly object _syncLock = new object();
    public static void WriteLogFile(string writedata)
    {
        lock (_syncLock)
        {
            string path = @"C:\rfa\Example.txt";
            using (TextWriter tw = new StreamWriter(path, true))
                tw.WriteLine(writedata);
        }
    }
