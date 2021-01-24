    static List<string> GetValsLol(string keyword, string input)
    {
        var rgxKeyword = new Regex(@"\[\s*(?:" + keyword + @"\s*.?=)\s*""(?<value>(?:[^""]*"")*?)\s*\]");
        var vals = new List<string>();
        int keywordIndex = 0;
        while (keywordIndex >= 0)
        {
            Match keyMatch = rgxKeyword.Match(input, keywordIndex);
            if (keyMatch.Success)
            {
                var trimmedVal = keyMatch.Groups["value"].Value.Trim();
                vals.Add(trimmedVal.Substring(0, trimmedVal.Length - 1));
                keywordIndex = keyMatch.Index + trimmedVal.Length;
            }
            else
                keywordIndex = -1;
        }
        return vals;
    }
