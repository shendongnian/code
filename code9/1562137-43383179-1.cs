    public virtual void Insert(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        //etc...
    }
