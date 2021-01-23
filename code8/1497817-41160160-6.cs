    public static class EnumerableExt
    {
        public static IEnumerable<T> Interleave<T>(this IEnumerable<T> a, IEnumerable<T> b)
        {
            using (var ae = a.GetEnumerator())
            using (var be = b.GetEnumerator())
            {
                bool aAvailable = true;
                bool bAvailable = true;
                while (aAvailable || bAvailable)
                {
                    aAvailable = aAvailable && ae.MoveNext();
                    bAvailable = bAvailable && be.MoveNext();
                    if (aAvailable)
                        yield return ae.Current;
                    if (bAvailable)
                        yield return be.Current;
                }
            }
        }
    }
