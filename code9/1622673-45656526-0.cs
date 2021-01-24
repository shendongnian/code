    public Dictionary<char, long> GetCharCount(string filePath)
    {
        var result = new Dictionary<char, long>();
        var content = File.ReadAllText(filePath);
        foreach(var c in content)
        {
            if (result.ContainsKey(c))
            {
                result[c] = result[c] + 1;
            }
            else
            {
                result.Add(c, 1);
            }
        }
        return result;
    }
