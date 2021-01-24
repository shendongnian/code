     public string GetLoggedInUserId()
     {
        ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                     .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
        return user.Id;
     }
