    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var authenticatedUserName = _httpContextAccessor.HttpContext.User.Identity.Name;
             // If it returns null, even when the user was authenticated, you may try to get the value of a specific claim 
             var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
             // var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst("sub").Value
            // TODO use name to set the shadow property value like in the following post: https://www.meziantou.net/2017/07/03/entity-framework-core-generate-tracking-columns
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
