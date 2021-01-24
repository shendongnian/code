    public class TestStartup : Startup
    {
        public new void Configuration(IAppBuilder app)
        {
            app.UseIpMiddleware(new IpOptions {RemoteIp = "127.0.0.1"});
            base.Configuration(app);          
        }
    }
