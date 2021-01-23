    public class CheckouthAttribute : FilterAttribute, IResultFilter
    {
            public void OnResultExecuting(ResultExecutingContext filterContext)
            {
                DoSomethingMethod();
            }
    }
    [Checkouth]
    public ActionResult Index()
    {
        return View();
    }
