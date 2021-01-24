    public AccountController
            (
                XUserManager userManager,
                XSignInManager signInManager,
                IDataService svc
            )
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _svc = svc;
        }
    public XUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<XUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
