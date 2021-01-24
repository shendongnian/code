    public static TimeSpan Mean(this ICollection<TimeSpan> source)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));
        long mean = 0L;
        long remainder = 0L;
        int n = source.Count;
        foreach (var item in source)
        {
            long ticks = item.Ticks;
            mean += ticks / n;
            remainder += ticks % n;
            mean += remainder / n;
            remainder %= n;
        }
        return TimeSpan.FromTicks(mean);
    }
