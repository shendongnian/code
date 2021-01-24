    public static IEnumerable<T> MergeWith<T>(
        this IEnumerable<T> source, IEnumerable<T> replacement)
    {
        using (var sourceIterator = source.GetEnumerator())
        using (var replacementIterator = replacement.GetEnumerator())
        {
            while (sourceIterator.MoveNext())
                yield return replacementIterator.MoveNext()
                    ? replacementIterator.Current
                    : sourceIterator.Current;
            while (replacementIterator.MoveNext())
                yield return replacementIterator.Current;
        }
    }
