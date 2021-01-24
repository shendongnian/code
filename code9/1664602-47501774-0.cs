        foreach (long iterator in paramIeId)
        {
            nyDbContext.Remove(new MyType() { ID = iterator });
        }
        try
        {
            nyDbContext.SaveChanges()
        }
        catch(DbUpdateConcurrencyException ex)
        {
            //if you want special handling for double delete
        }
    }
