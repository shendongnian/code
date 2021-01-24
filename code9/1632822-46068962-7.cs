    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
    	filterContext.RouteData.Values.Add("OneFilterUsed", "true");
    	base.OnActionExecuting(filterContext);
    }
    
    public ActionResult Index()
    {
    	if(RouteData.Values["OneFilterUsed"] == "true")
    	{
    
    	}
    
    	return View();
    }
