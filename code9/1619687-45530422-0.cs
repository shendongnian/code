    public class ApplicationDbContext : ApplicationDbContextBase
    {
        public ApplicationDbContext(
            IOptionsSnapshot<SiteSettings> siteSettings
            , IHttpContextAccessor httpContextAccessor
            , IHostingEnvironment hostingEnvironment
            , ILogger<ApplicationDbContextBase> logger)
            : base(siteSettings, httpContextAccessor, hostingEnvironment, logger)
        {
    }
