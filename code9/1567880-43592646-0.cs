    public static class EnumerableExtensions
    {
        private static readonly Random _rng = new Random();
        public static IEnumerable<T> Shuffle<T>( this IEnumerable<T> collection, Random rng = null )
        {
            rng = rng ?? _rng;
            var list = collection.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                var j = i + rng.Next( list.Count - i );
                yield return list[j];
                if (i != j)
                {
                    list[j] = list[i];
                }
            }
        }
    }
