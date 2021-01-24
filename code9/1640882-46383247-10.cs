    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {    
        Includes<T> includes = DbContextHelper.GetNavigations<T>();
        IQueryable<T> query = _context.Set<T>();
        if (includes != null)
        {
            query = includes.Expression(query);
        }
    
        var entity = await query.FirstOrDefaultAsync(predicate);
        return entity;
    }
