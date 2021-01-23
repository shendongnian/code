    public void AddItem<TEntity>(TEntity entity, Func<TEntity, bool> predicate)
	{
	    var objects = GetAllItems().ToList();
		// You might need some logic in the predicate to check for null
        if(!objects.Any(a => predicate(a as TEntity))
        {
            objects.Add(entity);
            _cache.AddReplaceCache(objects);
        }
    }
