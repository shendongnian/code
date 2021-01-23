    public virtual Task<TEntity> GetAsync(Guid id)
    {
        // some more code here
        return _dbSet.FindAsync(id);
    }
