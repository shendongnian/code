    public async Task Create(TEntity entity)
    {
        _dbSet.Add(entity);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Update(TEntity entity)
    {
        // entity has good data but SavaChangesAsync does nothing
        _dbSet.Update(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(long id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (_dbContext.Entry(entity).State = EntityState.Detached)
            _dbSet.Attach(entity);
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
