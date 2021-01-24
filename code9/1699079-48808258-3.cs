    public class RecordOwnerRequirement : IAuthorizationRequirement
    {
    }
    public class RecordOwnerHandler : AuthorizationHandler<RecordOwnerRequirement>
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IActionContextAccessor actionContextAccessor;
        public RecordOwnerHandler(ApplicationDbContext dbContext, IActionContextAccessor actionContextAccessor)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.actionContextAccessor = actionContextAccessor ?? throw new ArgumentNullException(nameof(actionContextAccessor));
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RecordOwnerRequirement requirement)
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
            var id = this.actionContextAccessor.ActionContext.RouteData.Values["id"];
            // Use the dbContext to compare the id against the database...
            // Return the result
            return true;
        }
    }
