    static IDictionary<string, string> Parse(string input)
    {
        var result = new Dictionary<string, string>();
        var pairs = input.Split(',');
        foreach (var pair in pairs)
        {
            var parts = pair.Split(new[] { ':' }, 2);
            string name = parts[0];
            string value = parts[1];
            result.Add(name, value);
        }
        return result;
    }
