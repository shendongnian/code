    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.SignalR;
    
    namespace YouDontNeedToKnow.Core.Main.Hubs
    {
        internal class MyHub : Hub
        {
            public static string HubName => "myHub";
    
            private readonly HubMethods<MyHub> _hubMethods;
    
            public PlayerServicesHub(HubMethods<MyHub> hubMethods)
            {
                _hubMethods = hubMethods;
            }
    
            public override Task OnConnectedAsync()
            {
                return base.OnConnectedAsync();
            }
        }
    }
