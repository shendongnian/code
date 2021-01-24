    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
