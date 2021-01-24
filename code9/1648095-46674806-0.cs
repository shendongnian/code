    Change ApplicationUser to inherit from IdentityUser<int>
    
    Create a new class ApplicationRole that inherits from IdentityRole<int>
    
    Change ApplicationDbContext to inherit from IdentityDbContext<ApplicationUser, ApplicationRole, int>
    
    Change startup.cs for services.AddIdentity to use ApplicationRole
    
    Change UrlHelperExtensions methods to take a generic <T> with T userId in the signature
    
    Change ManageController's LinkLoginCallback's call to await _signInManager.GetExternalLoginInfoAsync(user.Id.ToString())
    
    Add the following line to the ApplicationDbContext OnModelCreating method (after the base.OnModelCreating call)
    
    builder.Entity<ApplicationUser>().Property(p => p.Id).UseSqlServerIdentityColumn();
