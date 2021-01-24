    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Batches<T>(this IEnumerable<T> source, 
                                                                  int batchSize)
        {
            using (var enumerator = source.GetEnumerator())
                while (enumerator.MoveNext())
                    yield return enumerator.GetPage(batchSize);
        }
    
        private static IEnumerable<T> GetPage<T>(this IEnumerator<T> source, 
                                                      int batchSize)
        {
            for (var i = 0; i < batchSize; i++)
                if (i == 0 || source.MoveNext())
                    yield return source.Current;
                else
                    yield break; // not really needed but works as an early exit
        }
    }
