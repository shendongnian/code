    public class TestStartup : Startup
    {
	    public TestStartup(IHostingEnvironment env) : base(env)
	    {
	    }
	    public override void ConfigureServices(IServiceCollection services)
	    {
		    services
				.AddEntityFrameworkInMemoryDatabase()
				.AddDbContext<APIContext>((sp, options) =>
			    {
				    options.UseInMemoryDatabase().UseInternalServiceProvider(sp);
			    });
			base.ConfigureServices(services);
		}
	}
