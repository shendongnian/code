        public override void OnActionExecuting(ActionExecutingContext filterContext)
    { 
        filterContext.Result = new RedirectResult(url);
        return;   
     }
