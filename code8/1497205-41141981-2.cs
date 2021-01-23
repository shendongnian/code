    var sLines = File.ReadAllLines("filepath.txt")
                     .Where(s => !s.StartsWith("'"))
                     .Select(s => new 
                     { 
                         LineNumber = Regex.Match(s, "^\\d*").Value,
                         SValue = Regex.Match(s, "(?<=S)[\\d.]*").Value
                     })
                     .ToArray();
    // Use like this
	string lastSValue = "";
    foreach (var line in sLines)
    {
        string num = line.LineNumber;
        string val = line.SValue == string.Empty ? lastSValue : line.SValue;
		
		// Do the stuff
		
		lastSValue = val;
    }
