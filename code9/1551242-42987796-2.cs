    public Dictionary<string, string[]> GetSynonymSet(string synonymSetTextFileFullPath)
    {
        var dict = new Dictionary<string, string[]>();
        string line;
        // Read the file and display it line by line.
        using (var file = new StreamReader(synonymSetTextFileFullPath))
        {
            while((line = file.ReadLine()) != null)
            {
                var split = line.Split("|");
                if (!dict.ContainsKey(split[0]))
                {
                    dict.Add(split[0], split[1].Split(","));
                }
            }
        }
        return dict;
    }
