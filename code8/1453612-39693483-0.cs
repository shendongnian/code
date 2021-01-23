    public class AuthorizeWithSession : ActionFilterAttribute
    {       
        public override void OnActionExecuting(ActionExecutingContext context)
        {            
            string val;
            if (context.HttpContext.Session == null
                          || !context.HttpContext.Session.TryGetValue("LoggedUserID", out val))
            {
                context.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(
                                         new {controller = "Account", action = "Login"}));
          }
            base.OnActionExecuting(context);
        }
    }
