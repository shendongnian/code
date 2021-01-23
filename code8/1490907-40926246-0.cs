    static void Main(string[] args)
    {
        List<string> words = new List<string>() { "cat", "cats", "catsdogcats", "catxdogcatsrat", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
        List<string> result = new List<string>();
        // solution 1
        foreach (string word in words)
        {
            if (IsCombinationOf(word, words))
            {
                result.Add(word);
            }
        }
        // solution 2
        result = words.Where(x => IsCombinationOf(x, words)).ToList();
    }
    public static bool IsCombinationOf(string word, List<string> parts)
    {
        // removing the actual word just to be secure.
        parts = parts.Where(x => x != word).OrderByDescending(x => x.Length).ToList();
        // erase each part in word. Only those which are not in the list will remain.
        foreach (string part in parts)
        {
            word = Regex.Replace(word, part, "");
        }
        // if there are any caracters left, it hasn't been a combination
        return word.Length == 0;
    }
