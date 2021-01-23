    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> source, int combinationSize)
    {
        if (combinationSize > source.Count())
        {
            return new List<IEnumerable<T>>();
        }
        if (source.Count() == 1)
        {
            return new[] { source };
        }
        var indexedSource = source
            .Select((x, i) => new
            {
                Item = x,
                Index = i
            })
            .ToList();
        return indexedSource
            .SelectMany(x => indexedSource
                .OrderBy(y => x.Index != y.Index)
                .Skip(1)
                .OrderBy(y => y.Index)
                .Skip(x.Index)
                .Combinations(combinationSize - 1)
                .Select(y => new[] { x }.Concat(y).Select(z => z.Item))
            );
    }
