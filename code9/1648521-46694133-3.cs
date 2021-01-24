    var lines = File.ReadAllLines(fileName);
    var keyRegex = new Regex(@"\[(?<key>HKEY[^]]+)\]");
    var currentKey = string.Empty;
    var currentValue = string.Empty;
    var result = new Dictionary<string, string>();
    foreach (var line in lines)
    {
        var match = keyRegex.Match(line);
        if (match.Length > 0)
        {
            if (!string.IsNullOrEmpty(currentKey))
            {
                result.Add(currentKey, currentValue);
                currentValue = string.Empty;
            }
            currentKey = match.Groups["key"].ToString();
        }
        else
        {
            currentValue += line;
        }
    }
