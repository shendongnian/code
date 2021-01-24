    public static void WriteLogFile(string writedata)
    {
        using (TextWriter tw = new StreamWriter(path, true))
            tw.WriteLine(writedata);
    }
