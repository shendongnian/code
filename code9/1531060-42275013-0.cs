    public void Add(T entity)
    {
      if (entity == null) 
        return;
        
      var doc = new Document();
      entity.GetType().GetProperties().ToList().ForEach(x => doc[x.Name] = x.GetValue(entity));
      ...
    }
