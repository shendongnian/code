    var sLines = File.ReadAllLines("filepath.txt")
                     .Where(s => !s.StartsWith("'") && s.Contains("S"))
                     .Select(s => new 
                     { 
                         LineNumber = Regex.Match(s, "^\\d*").Value,
                         SValue = Regex.Match(s, "(?<=S)[\\d.]*").Value
                     })
                     .ToArray();
    // Use like this
    foreach (var line in sLines)
    {
        string num = line.LineNumber;
        string val = line.SValue;
    }
