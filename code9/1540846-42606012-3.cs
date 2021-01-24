    public List<T> GetSelection<T>(string a, Expression<Func<IMyTable<T>, T>> columnsToSelect = null)
    {
        IQueryable<IMyTable<T>> query  = (IQueryable<IMyTable<T>>) _myTableRepository.Where(c => c.Name == a);
    
        if (columnsToSelect == null)
            columnsToSelect = (Expression<Func<IMyTable<T>, T>>)(table => (table.GetAll()));
    
        return query.Select(columnsToSelect).ToList();
        
    }
