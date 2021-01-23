    public class AuthorizeWithSession : ActionFilterAttribute
    {       
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session == null ||
                                          context.HttpContext.Session["LoggedUserID"]==null)
            {
                context.Result =
                    new RedirectToRouteResult(new RouteValueDictionary(
                                         new {controller = "Account", action = "Login"}));
            }
            base.OnActionExecuting(context);
        }
    }
