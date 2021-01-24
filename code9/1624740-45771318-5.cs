    public class MyHub : Hub
    {
        //Consumed by signlar clients
        public static void ServerHubMethod()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            
            //Other logic 
    
            TestHelper.DoSomething();
    
        }
    }
