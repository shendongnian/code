    public static bool checker(string big, string small)
    {
        Dictionary<char, int> letterCount = new Dictionary<char, int>();
        foreach (char c in big)
        {
            if (!letterCount.ContainsKey(c))
            {
                letterCount[c] = 0;
            }
            letterCount[c]++;
        }
        return small.All(letter => letterCount.ContainsKey(letter) && --letterCount[letter] >= 0);
    }
