    using (var dbContext = new MyModel())
    {   
        if (dbContext.MyEntities.Any(e => e.ForeignId == f.ForeignId))
        {
            dbContext.MyEntities.Attach(f);
            dbContext.ObjectStateManager.ChangeObjectState(f, EntityState.Modified);
        }
        else
        {
            dbContext.MyEntities.AddObject(f);
        }
        
        dbContext.SaveChanges();
    }
