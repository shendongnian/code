        try
    {
        newJob.Company = ((CustomPrincipal)HttpContext.Current.User).MyUser.WorkinCompany;
        Random rnd = new Random();
        newJob.JobId = rnd.Next(1000000, 10000000); 
        
        // Keep Trying Random JobIDs until one doesn't already exist in the database
        while(_db.Jobs.Any(j => j.JobID == newJob.JobID))
            newJob.JobId = rnd.Next(1000000, 10000000); 
        
        realjob.RelatedJobs.Add(newJob);
        _db.Entry(realjob).State = EntityState.Modified;
    }
    catch (Exception e)
    {
         //Please do something with the exception!
    }
