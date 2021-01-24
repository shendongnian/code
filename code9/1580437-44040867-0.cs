    public static string Foo()
    {
        // see http://stackoverflow.com/questions/4890789/regex-for-an-ip-address
        Regex ip = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
        string[] inputLines = File.ReadAllLines("sourcefile.txt");
        List<string> outputLines = new List<string>();
        foreach (string line in inputLines)
        {
            MatchCollection result = ip.Matches(line);
            if (result[0].Success) outputLines.Add(line);
        }
        if (outputLines.Count > 0)
        {
            File.AppendAllLines("destinationfile.txt", outputLines);
        }
    }
