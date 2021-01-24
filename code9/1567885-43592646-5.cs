    public static class EnumerableExtensions
    {
        ...
        public static IEnumerable<T> RandomRepeat<T>(this IEnumerable<T> collection, int count, Random rng = null)
        {
            rng = rng ?? _rng;
            var list = collection.ToList();
            for ( int i = 0; i < count; i++ )
            {
                var j = rng.Next( list.Count );
                yield return list[j];
            }
        }
    }
