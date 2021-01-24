csharp
public class RecordOwnerHandler : AuthorizationHandler<RecordOwnerRequirement>
{
    private readonly ApplicationDbContext dbContext;
    private readonly IHttpContextAccessor httpContextAccessor;
    public RecordOwnerHandler(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
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
        if (!_httpContextAccessor.HttpContext.Request.RouteValues.TryGetValue("id", out var id))
        {
            return false;
        }
        // TODO Whatever logic you need to perform with the id
        return true;
    }
}
