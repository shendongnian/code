    public static IEnumerable<int> UniqueDigits(int start, int count)
    {
        for (var i = start; i < (start + count); i++)
        {
            var s = i.ToString();
            if (s.Distinct().Count() == s.Length)
            {
                yield return i;
            }
        }
    }
