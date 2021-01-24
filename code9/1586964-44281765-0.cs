    public static IEnumerable<string[]> SplitByLength(this string str, string[] splitBy, StringSplitOptions options, int maxLength = int.MaxValue)
    {
        var allTokens = str.Split(splitBy, options);
        for (int index = 0; index < allTokens.Length; index += maxLength)
        {
            int length = Math.Min(maxLength, allTokens.Length - index);
            string[] part = new string[length];
            Array.Copy(allTokens, index, part, 0, length);
            yield return part;
        }
    }
