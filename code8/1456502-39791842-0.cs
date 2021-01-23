    using (var context = new ResultContext())
    {
         DatabaseTestResults dbTestResults = new DatabaseTestResults();
    
         dbTestResults.ZipFileName = "report-nominal - Copy.zip";
    
         context.DbTestResults.Add(dbTestResults);
         context.Entry(dbTestResults).State = EntityState.Added
         context.SaveChanges();
    }
