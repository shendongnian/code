    public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
           this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new 
               ArgumentNullException(nameof(source));
            if (keySelector == null) throw 
                 new ArgumentNullException(nameof(keySelector));
    
            // This is basically executing _AnonymousFunction()
            return _AnonymousFunction(); 
            // This is a new inline method, 
            // return within this is only within scope of
            // this method
            IEnumerable<TSource> _AnonymousFunction()
            {
                var knownKeys = new HashSet<TKey>(comparer);
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }
