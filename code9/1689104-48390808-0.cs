    public class TeamAccessHandler : AuthorizationHandler<TeamAccessRequirement>
    {
        private readonly DbContext dbContext;
        public TeamAccessHandler(DbContext dbContext)
        {
            // example of an injected service. Put what you need here.
            this.dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TeamAccessRequirement requirement)
        {
            // pattern matching is cool. if you can't do this, use context.Resource as AuthorizationFilterContext before and check for not null
            if (context.Resource is AuthorizationFilterContext authContext)
            {
                // you can grab the team id, (but no model builder to help you, sorry)
                var teamId = Guid.Parse(authContext.HttpContext.Request.Query["teamId"]);
                // now you can do the code you would have done in the guts of the actions.
                if (context.User.IsTeamAdmin(teamId))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
