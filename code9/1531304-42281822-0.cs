    public ApplicationUserManager UserManager
    {
        get
        {
            return this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
    }
