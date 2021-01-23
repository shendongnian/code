    public class CheckouthAttribute : ActionFilterAttribute, IResultFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
             new RouteValueDictionary{{"controller", "Home" }, { "action", "Error" }});
        }
    }
    [Checkouth]
    public ActionResult Index()
    {
        return View();
    }
