    public static Dictionary<int, string> GetValuesToDictionary(string text)
    {
        var pattern = @"(\d+)=([^\d]+)";
        var regex = new Regex(pattern);
        var pairs = new Dictionary<int, string>();
        var matches = regex.Matches(text);
        foreach (Match match in matches)
        {
            var key = int.Parse(match.Groups[1].Value);
            var value = match.Groups[2].Value;
            if (!pairs.ContainsKey(key))
            {
                pairs.Add(key, value);
            }
            //pairs.Add(key, value);
        }
        return pairs;
    }
