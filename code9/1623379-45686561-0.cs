    foreach (var item in detailData)
    {
        Organization obj = new Organization()
        {
            addedby = item.addedby,
            organization = item.organization
            //Populate your other properties here.
        } 
        _dbContext.Organization.Add(obj);
        _dbContext.SaveChanges();
    }
