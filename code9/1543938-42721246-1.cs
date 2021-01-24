    public static IEnumerable<T> GetChunks<T>(this IEnumerable<T> source, IEnumerable<T> pattern)
        where T: IEquatable<T>
    {
        var dictionary = pattern.ToDictionary(p => p, p => new Stack<T>());
        foreach (var item in source)
        {
            dictionary[item].Push(item);
        }
        var rest = source.Except(pattern);
        while (dictionary.Values.Any(q => q.Any()))
        {
            foreach (var p in pattern)
            {
                if (dictionary[p].Count  >0)
                {
                    yield return dictionary[p].Pop();
                }
            }
        }
        foreach (var r in rest)
        {
            yield return r;
        }
    }
