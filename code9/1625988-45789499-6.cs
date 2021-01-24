    public class QueryStringAuthMiddleware : AuthenticationMiddleware<QueryStringAuthOptions>
    {
        public QueryStringAuthMiddleware(RequestDelegate next, IOptions<QueryStringAuthOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder)
            : base(next, options, loggerFactory, encoder)
        {
        }
    
        protected override AuthenticationHandler<QueryStringAuthOptions> CreateHandler()
        {
            return new QueryStringAuthHandler();
        }
    }
