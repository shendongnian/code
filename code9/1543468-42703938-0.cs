    public class RequestValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if(filterContext.Exception is HttpRequestValidationException)
            {
                filterContext.Result = new RedirectResult("/Error");
                filterContext.ExceptionHandled = true;
            }
        }
    }
