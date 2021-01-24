    public static Dictionary<string, int> OccurencesInText(this IEnumerable<string> words, string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
    {
        if (text == null) throw new ArgumentNullException(nameof(text));
        Dictionary<string, int> resultDict = new Dictionary<string, int>();
        foreach (string word in words.Distinct())
        {
            int wordOccurrences = 0;
            for(int i = 0; i < text.Length - word.Length; i++)
            {
                string substring = text.Substring(i, word.Length);
                if (substring.Equals(word, comparison)) wordOccurrences++;
            }
            resultDict.Add(word, wordOccurrences);
        }
        return resultDict;
    }
