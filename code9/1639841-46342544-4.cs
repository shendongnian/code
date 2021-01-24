    public TEntity GetEntityPlaceholder( int id )
    {
        var entity = new TEntity() { Id = id };
        _dbContext.Attach( entity );
        return entity;
    }
