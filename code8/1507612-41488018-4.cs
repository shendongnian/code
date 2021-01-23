    try
    {
        newJob.Company = ((CustomPrincipal)HttpContext.Current.User).MyUser.WorkinCompany;
        realjob.RelatedJobs.Add(newJob);
        _db.Entry(realjob).State = EntityState.Modified;
    }
    catch (Exception e)
    {
         //Please do something with the exception!
    }
