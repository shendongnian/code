      public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData
            };
        }
