    public class DbConfigurationContext
    {
        public string DbName { get; set; }
    }
    public class DbConfigurationContextFilter : IAsyncActionFilter
    {
        private readonly DbConfigurationContext _dbConfiguration;
        public DbConfigurationContextFilter(DbConfigurationContext dbConfiguration)
        {
            _dbConfiguration = dbConfiguration;
        }
        
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _dbConfiguration.DbName = context.HttpContext.Request.Query["DbName"];
            await next();
        }
    }
    services.AddTransient<DbConfigurationContext>();
    services.AddTransient<DbConfigurationContextFilter>();
    services.AddMvc(setup =>
    {
        setup.Filters.AddService(typeof(DbConfigurationContextFilter));
    })
