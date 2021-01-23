    public GuidUserManager UserManager
            {
                get
                {
                    return _userManager ?? HttpContext.GetOwinContext().GetUserManager<GuidUserManager>();
                }
                private set
                {
                    _userManager = value;
                }
            }
