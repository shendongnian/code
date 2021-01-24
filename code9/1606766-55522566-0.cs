    [AttributeUsage(AttributeTargets.Method]
        public class NotImplExceptionFilterAttribute : FilterAttribute, ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
