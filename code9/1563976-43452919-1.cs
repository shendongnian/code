    // Example of instantiating the User Manager
    private readonly UserManager<ApplicationUser> _userManager;
    public AccountController(UserManager<ApplicationUser> userManager)
    {
            _userManager = userManager;
    }
    // Example of adding a user to a given role
    public void AddUserToRole(string userId, string role)
    {
           var user = _userManager.FindByIdAsync(userId);
           if (user != null)
           {
                 await _userManager.AddToRoleAsync(user, role);
           }
    }
