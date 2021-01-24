    public static IEnumerable<Sublist> FindNonNullRanges(List<double?> numbers)
    {
        int start = -1;
        for (int i = 0; i < numbers.Count; ++i)
        {
            if (!numbers[i].HasValue)
            {
                if (start >= 0)
                {
                    yield return new Sublist(
                        start,
                        i - 1,
                        numbers.Skip(start).Take(i - start).Cast<double>().ToList());
                }
                start = -1;
            }
            else
            {
                if (start < 0)
                    start = i;
            }
        }
        if (start >= 0)
        {
            yield return new Sublist(
                start,
                numbers.Count-1,
                numbers.Skip(start).Take(numbers.Count - start).Cast<double>().ToList());
        }
    }
