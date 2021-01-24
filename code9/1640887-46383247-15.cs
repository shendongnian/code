    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {    
        Func<IQueryable<T>, IQueryable<T>> includes = DbContextHelper.GetNavigations<T>();
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            query = includes(query);
        }
    
        var entity = await query.FirstOrDefaultAsync(predicate);
        return entity;
    }
