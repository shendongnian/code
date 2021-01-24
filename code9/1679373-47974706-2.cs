    public Dictionary<TKey, TValue> GetEntityKeyValue<TEntity, TKey, TValue>
    (
        Func<TEntity, TKey> keySelector,
        Func<TEntity, TValue> valueSelector,
        Expression<Func<TEntity, bool>> keyPredicate
    ) where TEntity : class
    {
        return context.Set<TEntity>().Where(keyPredicate)
                      .ToDictionary(keySelector, valueSelector);
    }
