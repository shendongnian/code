    public bool Update(TEntity entity)
    {
                    
            context.Entry(entity).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            return true;
    }
