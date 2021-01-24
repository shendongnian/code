    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;
    public ApplicationSignInManager SignInManager
    {
        get
        {
            return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
        }
        private set
        {
            _signInManager = value;
        }
    }
    public ApplicationUserManager UserManager
    {
        get
        {
            return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        private set
        {
            _userManager = value;
        }
    }
