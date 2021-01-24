    public Dictionary<TKey, TValue> GetEntityKeyValue<TEntity, TKey, TValue>
    (
        Expression<Func<TEntity, TKey>> keySelector,
        Expression<Func<TEntity, TValue>> valueSelector,
        Expression<Func<TEntity, bool>> keyPredicate
    ) where TEntity : class
    {
        //at case of EF: context.Set<TEntity>().Where...
        return entity.Table.Where(keyPredicate).ToDictionary(keySelector, valueSelector);
    }
