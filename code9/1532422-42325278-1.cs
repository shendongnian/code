    using (var dbContextTransaction = dbContext.Database.BeginTransaction()) 
    { 
        try 
        { 
            var job = new Job{Name = "Name"}
            dbContext.Jobs.Add(job);
            dbContext.SaveChanges();
            var category = dbContext.Categories.Find(2);
            job.Categories.Add(category);
            dbContext.SaveChanges();
            dbContextTransaction.Commit(); 
        } 
        catch (Exception) 
        { 
            dbContextTransaction.Rollback(); 
        } 
    } 
