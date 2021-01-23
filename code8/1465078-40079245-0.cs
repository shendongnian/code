    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AllowCrossSiteJsonAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                filterContext.RequestContext.HttpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
    
            base.OnActionExecuting(filterContext);
        }
    }
