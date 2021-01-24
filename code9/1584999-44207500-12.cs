    public IQueryable<TTableEntity> GetList<TTableEntity>()
    {
        var dbObject = (DbSet<TTableEntity>)typeof(DbContext)
                            .GetMethod("Set", Type.EmptyTypes)
                            .MakeGenericMethod(typeof(TTableEntity))
                            .Invoke(databaseContext, null);
    
        return dbObject.AsQueryable();            
    }
