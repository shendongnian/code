    public static class IIdentityExtensions 
    {   
        public static string GetUserDisplayName(this IIdentity identity)
        {
           ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
           if (user != null)
           {
               return user.DisplayName;
           }
           return string.Empty;
        }
    }
