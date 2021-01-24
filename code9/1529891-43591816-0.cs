     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
        public sealed class SwaggerFileResponseAttribute : SwaggerResponseAttribute
        {
            public SwaggerFileResponseAttribute(HttpStatusCode statusCode) : base(statusCode)
            {
            }
    
            public SwaggerFileResponseAttribute(HttpStatusCode statusCode, string description = null, Type type = null)  : base(statusCode, description, type)
            {
            }
            public SwaggerFileResponseAttribute(int statusCode) : base(statusCode)
            {
            }
    
            public SwaggerFileResponseAttribute(int statusCode, string description = null, Type type = null) : base(statusCode, description, type)
            {
            }
        }
