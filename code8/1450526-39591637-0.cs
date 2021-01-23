    public static int MaxNumberOfConsecutiveCharacters(string s)
    {
        if (s == null) throw new ArgumentNullException(nameof(s));
        if (s.Length == 0) return 0;
        int maxCount = 1;
        int count = 1;
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i-1])
            {
                count++;
                if (count > maxCount) maxCount = count;
            }
            else
            {
                count = 1;
            }
        }
        return maxCount;
    }
