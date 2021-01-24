    public string Solution(string text)
    {
        string strResponse = string.Empty;
        if (!string.IsNullOrEmpty(text))
        {
            List<KeyValuePair<char, int>> occurance = text.GroupBy(ch => ch)
                                                          .Where(grp => char.IsLetter(grp.Key))
                                                          .Select(grp => new KeyValuePair<char, int>(grp.Key, grp.Count()))
                                                          .OrderByDescending(c => c.Value)
                                                          .ToList();
            if (occurance.Any())
                strResponse = occurance.First().Key.ToString();
        }
        return strResponse;
    }
