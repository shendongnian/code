    public static IEnumerable<int> Range(int start = 0, int stop = int.MaxValue, int step = 1)
    {
        if (step == 0)
            throw new ArgumentException(nameof(step));
        return RangeIterator(start, stop, step);
    }
