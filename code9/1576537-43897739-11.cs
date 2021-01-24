    public static IEnumerable<int> Range(int start, int stop, int step = 1)
    {
        if (step == 0)
            throw new ArgumentException(nameof(step));
        return RangeIterator(start, stop, step);
    }
