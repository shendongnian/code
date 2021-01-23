    foreach (var user in UserList)
    {
    	var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    	manager.PasswordValidator = new MinimumLengthValidator(3);
    
    	var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
    
    	var newUser = new ApplicationUser()
    	{
    		UserName = user.UserName,
    		UserId = user.UserId,
    		Email = user.Email,
    		FirstName = user.FirstName,
    		LastName = user.LastName,
    	};
    
    
    	// Assign the password
    	IdentityResult result = manager.Create(newUser, user.Password);
    
    	// Assign the role
    	var addedUser = manager.FindByName(user.UserName);
    	manager.AddToRoles(addedUser.Id, new string[] { "User" });
    
    }
