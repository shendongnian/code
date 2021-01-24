    public static class LinqExtensions
    {
        public static IEnumerable<TSource> SkipFirstWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return SkipFirstWhereIterator(source, predicate);
        }
        private static IEnumerable<TSource> SkipFirstWhereIterator<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            using (var e = source.GetEnumerator())
            {
                while (true)
                {
                    if (!e.MoveNext()) yield break;
                    if (predicate(e.Current)) break;
                    yield return e.Current;
                }
                while (e.MoveNext())
                    yield return e.Current;
            }
        }
    }
