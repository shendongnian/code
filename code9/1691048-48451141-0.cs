    using (var db = new DataContext())
    using (var userStore = new UserStore<ApplicationUser>(db))
    using (var userManager = new UserManager<ApplicationUser>(userStore))
    {
    	foreach (var oldUser in db.OldUsers)
    	{
    		var newUser = new IdentityUser
    		{
    			UserName = oldUser.UserName,
    			// set other properties
    		}
    		var result = userManager.Create(newUser);
    
    		if (!result.Succeeded)
    		{
    			// log error
    		}
    	}
    
    	db.OldUsers.RemoveRange(db.OldUsers);
    	db.SaveChanges();
    }
