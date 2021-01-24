    public static class EfHelpers {
        public static bool Equals<TKey>(TKey key, TKey other) {
            // not intended to call directly
            throw new NotImplementedException();
        }
    }
    public TEntity Get(TKey key) {
        // method has name "Equals", compatible signature and does not require
        // casting to object, so we are fine
        return _dbSet.Single(x => EfHelpers.Equals(x.Id, key));
    }
