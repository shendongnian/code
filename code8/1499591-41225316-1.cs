    static class ChunkExtension
    {
        public static IEnumerable<IEnumerable<T>> Chunkify<T>(
            this IEnumerable<T> source, int size)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (size < 1) throw new ArgumentOutOfRangeException("size");
            using (var iter = source.GetEnumerator())
            {
                while (iter.MoveNext())
                {
                    var chunk = new List<T>();
                    chunk.Add(iter.Current);
                    for (int i = 1; i < size && iter.MoveNext(); i++)
                        chunk.Add(iter.Current);
                    yield return chunk;
                }
            }
        }
    }
    int[] nums = new int[] { 1, 1, 1, 3, 1 };
    var groups = nums.GroupBy(n => n)
                     .Select(g => g.Chunkify(3)
                                   .Select(x => new { Value = g.Key, Count = x.Count() }))
                     .SelectMany(g => g);
