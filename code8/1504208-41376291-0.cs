    public bool Update(TEntity entity)
    {
        var entry = context.Entry(entity);
        if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
        {
            entry.State = EntityState.Modified; //do it here
    
            context.Set<TEntity>().Attach(entity); //attach
           
            context.SaveChanges(); //save it
        }
        return true;
    }
