    static class IdFetcher
    {
        public static int Fetch<T>(T item) => IdFetcher<T>.Fetch(item);
    }
    static class IdFetcher<T>
    {
        public static int Fetch(T item) => fetch(item);
        static readonly Func<T, int> fetch;
        static IdFetcher()
        {
            var p = Expression.Parameter(typeof(T), "item");
            fetch = Expression.Lambda<Func<T, int>>(
                Expression.PropertyOrField(p, "Id"), p).Compile();
        }
    }
