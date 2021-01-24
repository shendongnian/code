    var dict = new Dictionary<string, string>();
    // https://stackoverflow.com/questions/47246078/how-to-add-items-to-a-dictionary-from-a-linq-query
    var xdoc = XDocument.Load(@"D:\Practice\test.xml", LoadOptions.PreserveWhitespace);
    var regex = new Regex(@"deqn(\d+)-(\d+)");
    // Get matches by the regex
    var matches = from dispFormula in xdoc.Descendants("disp-formula")
                    select regex.Match(dispFormula.Attribute("id").Value);
    // We want only successes
    matches = matches.Where(match => match.Success);
    foreach (var match in matches)
    {
        // If input string is "deqn2-6", 
        //   match.Groups[0].Value = "deqn2-6", 
        //   match.Groups[1].Value = "2", 
        //   match.Groups[2].Value = "6", so
        int x = int.Parse(match.Groups[1].Value);
        int y = int.Parse(match.Groups[2].Value);
        // Now we have to increment x until y
        for (int i = 0; x + i <= y; i++)
        {
            dict.Add($"deqn{x + i}", $"deqn{x}-{y}");
        }
    }
    foreach (var entry in dict)
    {
        Console.WriteLine($"Key={entry.Key}, Value={entry.Value}");
    }
