    int lineNumber = 4;
    while (!reader.EndOfStream)
    {
        var line = ReadSpecificLine(reader,lineNumber);
        var values = line.Split(',');
        list.Add(values[0]);
    }
    public string ReadSpecificLine(StreamReader sr, int lineNumber)
    {
        for (int i = 1; i < lineNumber; i++)
            sr.ReadLine();
        return sr.ReadLine();
    }
