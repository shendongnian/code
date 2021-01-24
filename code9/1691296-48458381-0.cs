    var query = _dbSet.AsQueryable();
    //If the object implements a special interface
    if (typeof(IFoo).IsAssignableFrom(typeof(TEntity)))
    {
		query = query.Where("UserId = @0", _userId);
    }
    List<TEntity> d = await query.AsNoTracking().ToListAsync();
