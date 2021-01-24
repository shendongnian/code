        // ApplicationDriver has many child objects
        Infrastructure.Asset.ApplicationDriver driver = mapper.Map<Infrastructure.Asset.ApplicationDriver>(model);
        // get similar object from DB
        Infrastructure.Asset.ApplicationDriver currentApplication = db.ApplicationDrivers.Where(p => p.ApplicationId == model.ApplicationId).FirstOrDefault();
        if (currentApplication == null)
        {
            db.ApplicationDrivers.Add(driver);
        }
        else
        {
            //this will attach, and set state to modified
            //same as previous question, make sure you virtual properties are not populated to avoid unwanted duplicates. 
            db.Entry(driver).State = System.Data.Entity.EntityState.Modified; 
            currentApplication = driver;
        }
        await db.SaveChangesAsync();
