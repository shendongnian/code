     public class MyCustomAuthAttribute : FilterAttribute, IAuthorizationFilter
        {
            public string Permission { get; set; }
            public string Groups { get; set; }
    
            public void OnAuthorization(AuthorizationContext filterContext)
            {
                bool isauthorized = CheckIfUserIsAuthorized();
                if (!isauthorized)
                    context.Result = new HttpUnauthorizedResult(); // mark unauthorized
    
                // Only do something if we are about to give a HttpUnauthorizedResult and we are in AJAX mode.
                if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { Success = false, Message = "Unauthorized Access" },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    base.OnAuthorization(filterContext);
                    if (filterContext.Result is HttpUnauthorizedResult)
                    {
                        HttpContext.Current.Session.Abandon();
                        System.Web.Security.FormsAuthentication.SignOut();
                        filterContext.Result = new RedirectResult("Your Login Page.");
                    }
                }
            }
    
            private bool IsAuthorizedUser()
            {
                // use Permission, Groups and your logic
            }
        }
