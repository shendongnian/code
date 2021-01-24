    // Startup class of asp.net core 2
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMultitenancy<Tenant, TenantResolver>();
        string accountsConnection = configuration.GetConnectionString("AccountsConnectionString");
        services.AddScoped<LicenseManager>();
        services.AddScoped<AccountManager>();
                    
        
        services.AddEntityFrameworkSqlServer()
            .AddDbContext<AccountsContext>(options =>
            {
                options.UseSqlServer(accountsConnection);
            })
            .AddDbContext<MasterDataContext>(options => options.UseSqlServer(masterdataConnection))
            .AddDbContext<DataContext>();
        services.AddMvc();
    }
    // Tenantresolver which get's the connectionstring from the claims. (seperate file/class)
    // On authentication i create several claims with one claim with the connectionstring per user. 
    // I use a seperate accounts database where all the tenants are saved which each of them has his own connectionstring
    public class TenantResolver : MemoryCacheTenantResolver<Tenant>
    {
        private readonly AccountsContext Context;
        public TenantResolver(AccountsContext context, IMemoryCache cache, ILoggerFactory logger)
            :base(cache, logger)
        {
            Context = context;
        }
        protected override string GetContextIdentifier(HttpContext context)
        {
            return context.User.Claims.Where(r => r.Type == ClaimTypes.AccountIdType).Select(s => s.Value).SingleOrDefault();
        }
        protected override IEnumerable<string> GetTenantIdentifiers(TenantContext<Tenant> context)
        {
            return new[] { context.Tenant.Tenant_Id.ToString() };
        }
        
        protected override Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<Tenant> tenantContext = null;
            string claim = context.User.Claims.Where(r => r.Type == ClaimTypes.AccountIdType).Select(s => s.Value).SingleOrDefault();
            var tenant = Context.Accounts
                    .Where(q => q.IsActive == true && q.Account_Id.ToString() == claim)
                    .Select(s => new Tenant(s.Account_Id, s.DataStore.DatabaseConnection))
                    .FirstOrDefault();
            if (tenant != null)
            {
                tenantContext = new TenantContext<Tenant>(tenant);
            }
            return Task.FromResult(tenantContext);
        }
    }
    // Tenant class where i save the info needed.
    public class Tenant
    {
        public Tenant(
            Guid tenant_id,
            string database_ConnectionString)
        {
            Tenant_Id = tenant_id;
            Database_ConnectionString = database_ConnectionString;
        }
        public Guid Tenant_Id { get; set; }
        public string Database_ConnectionString { get; set; }
    }
    // DbContext class which uses the tenant and links the connectionstring to the current tenant.
    public class DataContext : DbContext
    {
        private readonly Tenant Tenant;
        public DataContext(DbContextOptions<DataContext> options, Tenant tenant)
            : base(options)
        {
            this.Tenant = tenant;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Tenant != null)
            {
                optionsBuilder.UseSqlServer(Tenant.Database_ConnectionString);
            }
            
            base.OnConfiguring(optionsBuilder);
        }
    }
