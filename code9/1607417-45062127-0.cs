    public virtual void Update<P>(List<Expression<Func<T, P>>> excludeColumns, params T[] items)
    {
         foreach (T item in items)
         {
             foreach (Expression<Func<T, P>> excludeColumn in excludeColumns)
             {
                _entities.Entry(item).State = EntityState.Modified;
                _entities.Entry(item).Property(excludeColumn).IsModified = false;       
             }
         }
    
        _entities.SaveChanges();
    }
