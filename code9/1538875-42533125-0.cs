    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()
        .GetUserManager<ApplicationUserManager>()
        .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
    //If you use int instead of string for primary key, use this:
    ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext()
        .GetUserManager<ApplicationUserManager>()
        .FindById(Convert.ToInt32(System.Web.HttpContext.Current.User.Identity.GetUserId()));
