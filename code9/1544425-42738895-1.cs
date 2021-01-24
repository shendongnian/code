     public class Startup    
     {
         public void Configuration(IAppBuilder app)
         {
             DisableWebSockets(GlobalHost.DependencyResolver);
      
             HubConfiguration hubConfiguration = new HubConfiguration();
             hubConfiguration.EnableDetailedErrors = true;
             app.MapSignalR(hubConfiguration);
         }
      
         public static void DisableWebSockets(IDependencyResolver resolver)
         {
             var manager = resolver.Resolve<ITransportManager()> as TransportManager;
             manager.Remove("webSockets");
         }
     }
