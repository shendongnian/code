    public static class Extensions {
        public static bool Equals<TKey>(this TKey key, TKey other) {
            throw new NotImplementedException();
        }
    }
    public TEntity Get(TKey key) {
        // method has name Equals and does not require casting to object
        // so we are fine
        return _dbSet.Single(x => x.ErrorID.Equals<TKey>(key));
    }
