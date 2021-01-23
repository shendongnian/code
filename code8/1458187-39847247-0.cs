    public void SetModified<T>(T entity) where T : class
    {
        var set = Set<T>();
        var entityFromCtx = set.Where(x => x.Id == entity.Id).FirstOrDefault();
        Entry(entityFromCtx).CurrentValues.SetValues(entity);
        //set.Attach(entity); // you don't need this anymore since you're not disposing the context yet.
        Entry(entityFromCtx).State = EntityState.Modified;
        //set.SaveChanges(); // I don't know if this fits here, but just don't forget it.
    }
