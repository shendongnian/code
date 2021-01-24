    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> source, int partitionSize)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (partitionSize <= 0)
                throw new ArgumentOutOfRangeException("partitionSize");
            return source
                .Select((e, i) => new { Part = i / partitionSize, Item = e })
                .GroupBy(e => e.Part, e => e.Item);
        }
    }
