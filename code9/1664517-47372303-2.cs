    public string Solution(string text)
    {
        string strResponse = string.Empty;
        if (!string.IsNullOrEmpty(text))
        {
            strResponse = text.GroupBy(ch => ch)
                              .Where(grp => char.IsLetter(grp.Key))
                              .Select(grp => new KeyValuePair<char, int>(grp.Key, grp.Count()))
                              .OrderByDescending(c => c.Value)
                              .First().Key.ToString();
        }
        return strResponse;
    }
