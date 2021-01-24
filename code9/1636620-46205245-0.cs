    public static TEntity Reload<TEntity>(this DbContext context, TEntity entity) where TEntity : class
    {
        return context.Entry(entity).Reload();
    }
 
    public static TEntity Reload<TEntity>(this EntityEntry<TEntity> entry) where TEntity : class
    {
        if (entry.State == EntityState.Detached)
        {
            return entry.Entity;
        }
 
        var context = entry.Context;
        var entity = entry.Entity;
        var keyValues = context.GetEntityKey(entity);
 
        entry.State = EntityState.Detached;
 
        var newEntity = context.Set<TEntity>().Find(keyValues);
        var newEntry = context.Entry(newEntity);
 
        foreach (var prop in newEntry.Metadata.GetProperties())
        {
            prop.GetSetter().SetClrValue(entity, 
            prop.GetGetter().GetClrValue(newEntity));
        }
 
        newEntry.State = EntityState.Detached;
        entry.State = EntityState.Unchanged;
 
        return entry.Entity;
    }
