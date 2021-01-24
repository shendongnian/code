    var path = Path to the file;
    List<string> lines = File.ReadAllLines(path).ToList();
    List<string> matches = new List<string>();
    
    for(int i = 0; i < lines.Count; i++)
    {
        var line = lines[i];
        if(line.Equals("Line1"))
        {
            if (lines.Count > i + 2)
            {
                matches.Add(lines[i++]);
                matches.Add(lines[i++]);
                matches.Add(lines[i++]);
            }
        }
    }
