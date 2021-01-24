    Dictionary<string, string> cache = new Dictionary<string, string>
    public string RandomString(string key = "")
    {
        string input = "";
        if (key.Trim() == "")
        {
            input = "abcdefghijklmnopqrstuvwxyz0123456789";
        }
        else
        {
            input = key;
        }
        if (cache.ContainsKey(input))
        {
            return cache[input];
        }
        else
        {
            var chars = Enumerable.Range(0, 5)                               
                .Select(x => input[random.Next(0, input.Length)]);
            var value = chars.ToArray();
            cache[input] = value;
            return value;
        }
    }
