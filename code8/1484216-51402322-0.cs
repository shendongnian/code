    public static Dictionary<string, int> WordCount(string text, int numWords = int.MaxValue)
    {
        var delimiterChars = new char[] { ' ', ',', ':', '\t', '\"', '\r', '{', '}', '[', ']', '=', '/' };
        return text
            .Split(delimiterChars)
            .Where(x => x.Length > 0)
            .Select(x => x.ToLower())
            .GroupBy(x => x)
            .Select(x => new { Word = x.Key, Count = x.Count() })
            .OrderByDescending(x => x.Count)
            .Take(numWords)
            .ToDictionary(x => x.Word, x => x.Count);
    }
