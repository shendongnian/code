    public class ActionFilterAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //throw new NotImplementedException();
        }
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if(viewResult != null)
            {
                var viewEngine = ViewEngines.Engines.FindPartialView(filterContext.Controller.ControllerContext, viewResult.ViewName);
                var razorView = viewEngine.View as RazorView;
                if (razorView != null)
                {
                    using (var reader = new StreamReader(filterContext.HttpContext.Server.MapPath(razorView.ViewPath)))
                    {
                        var markups = reader.ReadToEnd();
                    }
                }
            }
        }
    }
