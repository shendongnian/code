    public static class Extensions {
        public static bool Equals<TKey>(this TKey key, TKey other) {
            throw new NotImplementedException();
        }
    }
    public TEntity Get(TKey key) {
        return _dbSet.Single(x => x.ErrorID.Equals<TKey>(key));
    }
