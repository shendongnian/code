    public TEntity AddOrUpdate<TEntity>(DbContext context, TEntity entity)
        where TEntity : class
    {
        context.Entry(entity).State =
            context.KeyValuesFor(entity).All(IsDefaultValue)
                ? EntityState.Added
                : EntityState.Modified;
     
        return entity;
    }
     
    private static bool IsDefaultValue(object keyValue)
    {
        return keyValue == null
               || (keyValue.GetType().IsValueType
                   && Equals(Activator.CreateInstance(keyValue.GetType()), keyValue));
    }
