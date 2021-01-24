    public override int SaveChanges()
    {
     
        var modifiedUsers = ChangeTracker.Entries<User>().Where(x => x.State 
                                               == EntityState.Modified).ToList();
        modifiedUsers.ForEach(x => 
        {
            x.Update.DateOfUpdate = DateTime.Now;
        });
        return base.SaveChanges();
    }
