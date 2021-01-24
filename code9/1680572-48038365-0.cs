    private static IEnumerable<string> GetLongestPotentialPalindromes2(string input)
    {
        HashSet<char> odds = new HashSet<char>();
        void AddToSet(char c)
        {
            if (!odds.Add(c)) { odds.Remove(c); }
        }
    
        for (int len = input.Length; len > 0;)
        {
            odds.Clear();
            for (int i = 0; i < len - 1; ++i)
            {
                AddToSet(input[i]);
            }
            int minOddCount = int.MaxValue;
            for (int start = 0; start <= input.Length - len; ++start)
            {
                AddToSet(input[start + len - 1]);
                int oddCount = odds.Count;
                if (oddCount <= 1) { yield return input.Substring(start, len); }
                minOddCount = Math.Min(minOddCount, oddCount);
                AddToSet(input[start]);
            }
            if (minOddCount <= 1) { yield break; }
            len -= minOddCount - 1;
        }
    }
