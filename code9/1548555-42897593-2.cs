    public virtual void Update<P>(Expression<Func<T, P>> excludeColumn, params T[] items)
    {
        foreach (T item in items)
        {
            _entities.Entry(item).State = EntityState.Modified;                
            _entities.Entry(item).Property(excludeColumn).IsModified = false;
        }
        _entities.SaveChanges();
    }
