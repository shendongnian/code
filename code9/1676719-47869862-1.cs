        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is HttpException)
            {
                HttpException exception = filterContext.Exception as HttpException;
                if (exception.ErrorCode == 600)
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Error" }, 
                    { "controller", "Error" }
                });
                filterContext.ExceptionHandled = true;
            }
        }
