    [AttributeUsage(AttributeTargets.Method]
        public class NotImplExceptionFilterAttribute : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext) {
            {
                if (filterContext.Exception is NotImplementedException)
            {
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
