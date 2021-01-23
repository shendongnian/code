    public class ValidUserAuthorization<TDbContext> : AuthorizationHandler<ValidUserAuthorization>, IAuthorizationRequirement
        where TDbContext : DbContext, new()
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ValidUserAuthorization requirement)
        {
            using (TDbContext db = new TDbContext())
            {
                // ...
            }
        }
    }
