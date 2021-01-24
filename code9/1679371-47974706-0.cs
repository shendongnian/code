    public Dictionary<TKey, TValue> GetEntityKeyValue<TEntity, TKey, TValue>
    (
        Expression<Func<TEntity, TKey>> keySelector,
        Expression<Func<TEntity, TValue>> valueSelector,
        Expression<Func<TEntity, bool>> keyCondition
    )
    {
                   //or entity.Table
        return context.Set<TEntity>().Where(keyCondition)
                      .ToDictionary(keySelector, valueSelector);
    }
