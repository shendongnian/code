    private readonly UserManager<ApplicationUser> _userManager;
    public AccountController(UserManager<ApplicationUser> userManager)
    {
            _userManager = userManager;
    }
    public void AddUserToRole(string userId, string role)
    {
           var user = _userManager.FindByIdAsync(userId);
           if (user != null)
           {
                 await _userManager.AddToRoleAsync(user, role);
           }
    }
