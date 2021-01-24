    private static Char[] GetMostFrequentChars(String text)
    {
        Dictionary<Char,Int32> rank = new Dictionary<Char,Int32>();
    
        foreach (Char c in text.Where(c => !char.IsWhiteSpace(c)))
        {
            if (rank.ContainsKey(c))
                rank[c]++;
            else
                rank.Add(c, 1);
        }
    
        return rank.Where(r => r.Value == rank.Values.Max()).Select(x => x.Key).ToArray();
    }
