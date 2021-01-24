    public class AuthFilter : IAuthorizationFilter
    {
        public bool AllowMultiple => false;
        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            // incorrect use of async in this Filter will break async in future filters
            return await continuation();
        }
    }
