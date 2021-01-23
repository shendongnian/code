    public class MyAwesomeController : MyControllerBase
    {
        public ActionResult Index()
        {
            //this.SectionCode is available populated here
            return View();
        }
    }
    public class MyControllerBase : Controller
    {
        public string SectionCode
        {
            get;
            private set;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.SectionCode = filterContext.RequestContext.RouteData.Values["code"].ToString();
            base.OnActionExecuting(filterContext);
        }
    }
