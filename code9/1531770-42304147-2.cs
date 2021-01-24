    public static IEnumerable<int> Range(int start, int increment)
    {
        for (; ; )
        {
            yield return start;
            start += increment;
        }
    }
