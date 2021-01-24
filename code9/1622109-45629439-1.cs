    public override int SaveChanges()
    {
        var addedUsers = ChangeTracker.Entries<User>().Where(x => x.State 
                                           == EntityState.Added).ToList();
        addedUsers.ForEach(x => 
        {
            x.Update = new Update{DateOfUpdate = DateTime.Now}
        });
      
        var modifiedUsers = ChangeTracker.Entries<User>().Where(x => x.State 
                                               == EntityState.Modified).ToList();
        modifiedUsers.ForEach(x => 
        {
            x.Update.DateOfUpdate = DateTime.Now;
        });
        return base.SaveChanges();
    }
