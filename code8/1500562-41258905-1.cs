    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (!bool.Parse(ConfigurationManager.AppSettings["WebJobsShouldWork"] ?? "true"))
            filterContext.Result = new EmptyResult();
    }
