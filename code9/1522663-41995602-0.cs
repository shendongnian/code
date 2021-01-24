    public virtual TEntity Get<TEntity, TId>(TId id) 
        where TEntity : class, IEntity<TId>
        where TId: IEquatable<TId>
    {
        return dbContext.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
    }
