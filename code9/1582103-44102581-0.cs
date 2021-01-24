    //...ctor
    public Repository(DbContext context) {
        Context = context;
        _entities = Context.Set<TEntity>(); //<-- Note method used to access DbSet
    }
    //...
