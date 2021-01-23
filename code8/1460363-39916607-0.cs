    private static List<string> GetSpamWords(string text, IEnumerable<string> wordBlacklist)
    {
                string temp = text.ToLower();
                return wordBlacklist.Where(s => temp.Contains(s)).ToList();           
    }
