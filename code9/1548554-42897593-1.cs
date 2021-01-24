    public virtual void Update(T[] items, params Expression<Func<T, object>>[] excludeColumns)
    {
        foreach (T item in items)
        {
            _entities.Entry(item).State = EntityState.Modified;
            foreach (var predicate in excludeColumns)            
                _entities.Entry(item).Property(predicate).IsModified = false;
        }
        _entities.SaveChanges();
    }
