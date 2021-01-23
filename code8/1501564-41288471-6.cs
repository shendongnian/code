    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "Serilog-{Date}.txt"))
               .CreateLogger();
            Log.Information("Inside Startup ctor");
            ....
        }
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Information("ConfigureServices");
            ....
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Log.Information("Configure");
            ....
        }
