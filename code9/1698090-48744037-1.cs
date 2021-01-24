    public static class EfExtensions {
        public static Task<TSource[]> ToArrayAsyncSafe<TSource>(this IQueryable<TSource> source) {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (!(source is IDbAsyncEnumerable<TSource>))
                return Task.FromResult(source.ToArray());
            return source.ToArrayAsync();
        }
    }
