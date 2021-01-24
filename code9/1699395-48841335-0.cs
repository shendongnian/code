    public class RedirectUnauthorizedRoles : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
            }
            else
            {
    
               //Example if User is Valid then i will return 1 else it will return 0
                var value = true ? "1" : "0";
    
                filterContext.Result = new JsonResult()
                {
                    Data = value
                };
            }
        }
    }
