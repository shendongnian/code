    protected override void Seed(Project.NameSpace.ApplicationDbContext context)
    {
        
        var userStore = new UserStore<ApplicationUser>(context);
        var userManager = new UserManager<ApplicationUser>(userStore);
        
        var user = new ApplicationUser 
        {
          UserName = "",
          FirstName = "",
          LastName = "",
          ...
        };
        
        userManager.Create(user, "ADD_PASSWORD_HERE"); // make sure that you follow the validation of your password here so you won't encounter any error. (Like password must have at least 1 number or special character and etc..)
    }
