    public class CustomExceptionFilter : HandleErrorAttribute {
        public override void OnException(ExceptionContext filterContext) {
    
            var controller = filterContext.Controller as Controller;
            controller.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            controller.Response.TrySkipIisCustomErrors = true;
            filterContext.ExceptionHandled = true;
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var exception = filterContext.Exception;
            //need a model to pass exception data to error view
            var model = new HandleErrorInfo(exception, controllerName, actionName);    
            var view = new ViewResult();
            view.ViewName = "Error";
            view.ViewData = new ViewDataDictionary();
            view.ViewData.Model = model;
            //copy any view data from original control over to error view
            //so they can be accessible.
            var viewData = controller.ViewData;
            if (viewData != null && viewData.Count > 0) {
                viewData.ToList().ForEach(view.ViewData.Add);
            }
            //Instead of this
            ////filterContext.Result = view;
            //Allow the error view to display on the same URL the error occurred
            view.ExecuteResult(filterContext);
            //should do any logging after view has already been rendered for improved performance.
            //_logger.Error("Uncaught exception", exception);
     
        }
    }
