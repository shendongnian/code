    public static class Ext {
        public static T MaxBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> key, Comparer<TKey> keyComparer = null) {
            var max = src.First();
            var maxKey = key(max);
            keyComparer = keyComparer ?? Comparer<TKey>.Default;
            foreach (var n in src.Skip(1)) {
                if (keyComparer.Compare(key(n), maxKey) > 0) {
                    max = n;
                    maxKey = key(n);
                }
            }
    
            return max;
        }
    }
