    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            this.Configuration = builder.Build();
            var hangFireCS = this.Configuration.GetConnectionString("HangFire");
        }
    }
