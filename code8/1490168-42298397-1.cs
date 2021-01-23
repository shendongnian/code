    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
            app.Map("/signalr", map =>
            {
               
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                  
                };
    
              
                map.RunSignalR(hubConfiguration);
            });
        }
    }
    [HubName("shopApiHub")]
    public class ShopApiHub : Hub
    {
        
        public override Task OnConnected()
        {
            ShopAPIAccess.WriteToFile("connection ID= " + Context.ConnectionId);
            return base.OnConnected();
        }
