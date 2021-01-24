    public virtual void AddOrUpdateEntity<TEntity>(IProMetrixContext db, 
    TEntity[] entities) where TEntity : class
    {
         db.Set<TEntity>().AddOrUpdate(entities);
    }   
