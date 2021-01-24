    public class TestStartup : Startup
    {
        public TestStartup(IHostingEnvironment env) : base(env) { }
        public override void ConfigureServices(IServiceCollection services)
        {
            //mock DbContext here
        }
    }
