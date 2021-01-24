    private static IEnumerable<int> Step(int start, int end)
    {
        if (start < end)
        {
            for (int x = start; x <= end; x++)
                yield return x;
        }
        else
        {
            for (int x = start; x >= end; x--)
                yield return x;
        }
    }
