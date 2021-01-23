    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
    
        base.OnActionExecuting(filterContext);
    
        var password = filterContext.ActionParameters.ContainsKey("password") 
                    ? filterContext.ActionParameters["password"] : null;
        ....
    
    }
