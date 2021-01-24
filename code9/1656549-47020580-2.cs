            public override void OnException(ExceptionContext filterContext)
            {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
    
                filterContext.Result = new ViewResult
                {
                    ViewName = "CustomError",
                    MasterName = Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };
    
                filterContext.ExceptionHandled = true;
                
            }
        }
