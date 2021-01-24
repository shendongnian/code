    using (SampleEntities context = new SampleEntities())
    {
        using (System.Data.Entity.DbContextTransaction trans = context.Database.BeginTransaction( ))
        {
            context.SampleJobs.Add(newJob);
            context.SaveChanges();
            var jobId = newJob.Id;
            //do other things, then commit or rollback
        }
    }
