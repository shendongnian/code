    using (var transactionScope = new TransactionScope()) 
    { 
        var job = new Job{Name = "Name"}
        dbContext.Jobs.Add(job);
        dbContext.SaveChanges();
        var category = dbContext.Categories.Find(2);
        job.Categories.Add(category);
        dbContext.SaveChanges();
        transactionScope.Complete(); 
    } 
