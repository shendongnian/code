    public virtual Task<TEntity> GetAsync(Guid id, params Expression<Func<TEntity, object>>[] includeProperties))
    {
        // some more code here
        return _dbSet.FindAsync(id);
    }
