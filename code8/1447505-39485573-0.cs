    public static IEnumerable<IList<T>> Rotate<T>(this IEnumerable<IList<T>> sequences)
    {
        var list = sequences as IList<IList<T>> ?? sequences.ToList();
        int maxCount = list.Max(l => l.Count);
        return Enumerable.Range(0, maxCount)
            .Select(i => list.Select(l => l.ElementAtOrDefault(i)).ToList());
    }
