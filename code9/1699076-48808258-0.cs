    public class RecordOwnerRequirement : IAuthorizationRequirement
    {
    }
    public class RecordOwnerHandler : AuthorizationHandler<RecordOwnerRequirement>
    {
        private readonly ApplicationDbContext dbContext;
        public RecordOwnerHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            RecordOwnerRequirement requirement)
        {
            if (IsUserAuthorized(context))
            {
                context.Succeed(requirement);
            }
            //TODO: Use the following if targeting a version of
            //.NET Framework older than 4.6:
            //      return Task.FromResult(0);
            return Task.CompletedTask;
        }
        private bool IsUserAuthorized(AuthorizationHandlerContext context)
        {
            // Check if user is authorized
            // this.dbContext ...
            // Return the result
            return true;
        }
    }
