    public TestController(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
    {
        UserManager = userManager;
        var curUser = UserManager.GetUserAsync(httpContextAccessor.HttpContext.User).Result;
        if (curUser.Name == "Admin")
            _userName = HttpContext.Session.GetString("selectedUser"); 
    }
