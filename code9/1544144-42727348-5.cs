    List<string> parts = new List<string>();
    while ((line = file.ReadLine()) != null)
    {
        parts = new List<string>();
        //string partOne = Regex.Match(line, @"[A-Za-z](.*)[A-Za-z]").Value;
        //Update Regex for handle numeric value in part one.
        string partOne = Regex.Match(line, @"[A-Za-z](.*)([A-Za-z]|([A-Za-z]{1}[0-9]))(.*?)\s").Value.Trim();
        parts.Add(partOne);
        string[] fianlParts;
        if (!string.IsNullOrEmpty(partOne))
        {
            fianlParts = Regex.Split(line.Replace(partOne, ""), @"(\s+)");
        }
        else
        {
            fianlParts = Regex.Split(line, @"(\s+)");
        }
        foreach (string part in fianlParts)
        {
            if (!string.IsNullOrEmpty(part.Trim()))
            {
                parts.Add(part);
            }
        }
        Console.WriteLine(parts[0] + " " + parts[1] + " " + parts[2] + " " + parts[3]);
    }
