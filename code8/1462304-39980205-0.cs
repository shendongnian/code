    public class CustomAuthenticationAttribute : Attribute, System.Web.Http.Filters.IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                return true;
            }
        }
    
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
                context.Principal = //get principal here, based on your implementation
        }
    
        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            await Task.FromResult(0);
        }
    }
