    public class BudgetAccessFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //context.HttpContext.User.Identity.Name
            //TODO: determine if user has access to budget controllers, all of them could inherit from a Common Controller with this Filter
            if (false)
            {
                //if no access then
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }     
    }
