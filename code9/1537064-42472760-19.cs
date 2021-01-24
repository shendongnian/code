    private async Task CreateRoles(IServiceProvider serviceProvider)
    {
        //initializing custom roles 
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        string[] roleNames = { "Admin", "Manager", "Member" };
        IdentityResult roleResult;
    
        foreach (var roleName in roleNames)
        {
            var roleExist = await RoleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                //create the roles and seed them to the database: Question 1
                roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    
        //Here you could create a super user who will maintain the web app
        var poweruser = new ApplicationUser
        {    
            UserName = Configuration["AppSettings:UserName"],
            Email = Configuration["AppSettings:UserEmail"],
        };
    
        //Ensure you have these values in your appsettings.json file
        string userPWD = Configuration["AppSettings:UserPassword"];
        var _user = await UserManager.FindByEmailAsync(Configuration["AppSettings:AdminUserEmail"]);
    
        if (_user == null)
        {
            var createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
            if (createPowerUser.Succeeded)
            {
                //here we tie the new user to the role
                await UserManager.AddToRoleAsync(poweruser, "Admin");
            }
        }
    }
 
