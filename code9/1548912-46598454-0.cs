    public Task<List<TEntity>> GetAll()
        {
            var query = _Db.Set<TEntity>().AsQueryable();
            foreach (var property in _Db.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);
            return query.ToListAsync();
        }
