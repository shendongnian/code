    public static void WriteLogFile(string writedata)
    {
        string path = @"C:\Example.txt";
        using (TextWriter tw = new StreamWriter(path, true))
            tw.WriteLine(writedata);
    }
