    public static IEnumerable<T> Merge<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        using (var firstEnumerator = first.GetEnumerator())
        using (var secondEnumerator = second.GetEnumerator())
        {
            while (firstEnumerator.MoveNext())
            {
               yield return firstEnumerator.Current;
                if (secondEnumerator.MoveNext())
                {
                    yield return secondEnumerator.Current;
                }
            }
            while (secondEnumerator.MoveNext())
            {
                yield return secondEnumerator.Current;
            }
        }
    }
