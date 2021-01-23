        public override void Log(ExceptionLoggerContext context)
        {
            HttpContext httpContext = GetHttpContext(context.Request);
            ExceptionService.LogException(context.Exception);
        }
        private static HttpContext GetHttpContext(HttpRequestMessage request)
        {
            HttpContextBase contextBase = GetHttpContextBase(request);
            if (contextBase == null)
            {
                return null;
            }
            return contextBase.ApplicationInstance.Context;
        }
        private static HttpContextBase GetHttpContextBase(HttpRequestMessage request)
        {
            if (request == null)
            {
                return null;
            }
            object value;
            if (!request.Properties.TryGetValue("MS_HttpContext", out value))
            {
                return null;
            }
            return value as HttpContextBase;
        }
