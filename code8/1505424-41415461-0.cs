    public void ConfigureServices(IServiceCollection services) {
        var connection = @"Data Source=.;Initial Catalog=RestfullServices;Integrated Security=true";
        services.AddDbContext<Context>(options => options.UseSqlServer(connection));
        services.AddScoped<IContext, Context>();
        services.AddApplicationInsightsTelemetry(Configuration);
        services.AddMvc();
    }
