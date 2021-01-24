    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        string newline = line.Substring(3);
        ...
    }
