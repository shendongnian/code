    public static IEnumerable<string> GenerateCombinatins<T>(
        this string s,
        IEnumerable<T> set,
        char wildcard)
    {
        var length = s.Where(c => c == wildcard).Count();
        var combinations = GetAllCombinations(set, length);
        var builder = new StringBuilder();
        foreach (var combination in combinations)
        {
            var index = 0;
            foreach (var c in s)
            {
                if (c == wildcard)
                {
                    builder.Append(combination[index]);
                    index += 1;
                }
                else
                {
                    builder.Append(c);
                }
            }
            yield return builder.ToString();
            builder.Clear();
        }
    }
