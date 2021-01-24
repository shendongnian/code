    while ((line = file.ReadLine()) != null)
    {
        string partOne = Regex.Match(line, @"[a-z](.*)[a-z]").Value;
        string[] parts = Regex.Split(line.Replace(partOne, ""), @"(\s+)");
    }
