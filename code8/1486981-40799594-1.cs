    private static char[] GetMostFrequentChar(string str)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();
        foreach (char c in str)
        {
            if (chars.ContainsKey(c)) chars[c]++;
            else chars.Add(c, 1);
        }
        int max = chars.Values.Max();
        return chars.Where(b => b.Value == max).Select(b => b.Key).ToArray();
    }
