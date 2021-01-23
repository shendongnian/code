    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
            base.OnActionExecuting(filterContext);
            
            if (Session["UserLogin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "ManageAccount" }, { "action", "Login" } });
            }
        }
    }
