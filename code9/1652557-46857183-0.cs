    public static IEnumerable<string> ReadAllLines(string path)
    {
        if (!File.Exists(path)) return null;
        var lines = new List<string>();
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                // add the TrimEnd call here
                lines.Add(reader.ReadLine().TrimEnd());
            }
        }
        return lines.ToArray();
    }
