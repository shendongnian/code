        public class ServiceStatusHub : Hub
        {
            private static IHubContext hubContext = 
            GlobalHost.ConnectionManager.GetHubContext<ServiceStatusHub>();
            public static void GetStatus(string message)
            {
                hubContext.Clients.All.acknowledgeMessage(message);
            }
        }
