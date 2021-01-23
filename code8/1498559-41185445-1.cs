    static string ReplaceEvenOdd(string s, string syntax, string odd, string even)
    {
        string[] split = s.Split(new[] { syntax }, StringSplitOptions.None);
        string result = string.Empty;
        for (int i = 0; i < split.Length; i++)
        {
            result += split[i];
            if (i < split.Length - 1)
                result += (i + 1) % 2 == 0 ? even : odd;
        }
        return result;
    }
