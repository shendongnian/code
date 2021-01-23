    public override int SaveChanges()   
    {   
        var deletedMyFileEntityList = ChangeTracker.Entries()   
            .Where(f => f.Entity is MyFile && f.State == EntityState.Deleted);   
        foreach (var entity in deletedMyFileEntityList)   
        {
            try {
                entity.DisposeFile();
            }
            catch (Exception ex)
            {
                // Here you can decide what to do if the DisposeFile method fails
            }
        }   
        return base.SaveChanges();   
    }
