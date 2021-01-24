    public virtual void AvoidPropertyModify<TEntity, TProperty>(
        TEntity entity, 
        Expression<Func<TEntity, TProperty>> getProperty)
        where TEntity : class
    {
        var entityEntry = Context.Entry(entity);
        var propertyEntry = entityEntry.Property(getProperty);
        propertyEntry.IsModified = false;
    }
    public void Update(Customer customer)
    {
        AvoidPropertyModify(customer, x => x.Number); 
    }
    
