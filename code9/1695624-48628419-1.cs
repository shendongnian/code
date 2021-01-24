    public TEntity GetByKey<TEntity>(int key)
      where TEntity : IHasKeyProperty, class
    {
      return this._dbContext.Set<TEntity>().FirstOrDefault(x => x.Id == key);
    }
