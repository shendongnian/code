    var builder = new DbContextOptionsBuilder<MapDbContext>();
    builder.UseSqlServer(ConfigurationManager.ConnectionStrings["MapDbConnectionStr"].ConnectionString), opt => opt.EnableRetryOnFailure());
    var mycontext = new MapDbContext(builder.Options);
    public MapDbContext(DbContextOptions<MapDbContext> options)
            : base(options)
        { }
