    public class AuthorizationAttribute : AuthorizeAttribute
    {
       protected override bool AuthorizeCore(HttpContextBase httpContext)
       {
          //check if user in in role admin and if yes then return true, else return false. Once it returns false, then HandleUnauthorizedRequest will be triggered automatically
          return userManager.IsUserInAdminRole(username);
       }
    
       protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
       {
          filterContext.Result = new RedirectResult("~/Error/ForbiddenPage");
       }
    }
