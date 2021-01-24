    public static class Ext {
        public static T MaxBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> key, Comparer<TKey> keyComparer = null) {
            using (var esrc = src.GetEnumerator()) {
                if (esrc.MoveNext()) {
                    keyComparer = keyComparer ?? Comparer<TKey>.Default;
    
                    var max = esrc.Current;
                    var maxKey = key(max);
                    while (esrc.MoveNext()) {
                        var n = esrc.Current;
                        if (keyComparer.Compare(key(n), maxKey) > 0) {
                            max = n;
                            maxKey = key(n);
                        }
                    }
    
                    return max;
                }
                else
                    throw new InvalidOperationException("Sequence contains no elements");
            }
        }
    }
