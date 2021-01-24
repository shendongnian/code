    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.
    
            return base.OnStart();
        }
    
        public override void Run()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(30000);
    
                var hub = new Microsoft.AspNet.SignalR.Client.HubConnection("http://localhost:57276/signalr/hubs");
    
                var proxy = hub.CreateHubProxy("ChatHub");
                hub.Start().Wait();
    
                //invoke hub method
                proxy.Invoke("mySend", "hello from webrole; " + DateTime.UtcNow.ToString());
            }         
        }
    
    
    }
