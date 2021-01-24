    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    
    namespace YouDontNeedToKnow.Core.Main.Hubs
    {
        internal class HubMethods<THub> where THub : Hub
        {
            private readonly IHubContext<THub> _hubContext;
    
            public HubMethods(IHubContext<THub> hubContext)
            {
                _hubContext = hubContext;
            }
    
            public Task InvokeOnGroupAsync(string groupName, string method, params object[] args) =>
                _hubContext.Clients.Group(groupName).InvokeAsync(method, args);
    
            public Task InvokeOnAllAsync(string method, params object[] args) =>
                _hubContext.Clients.All.InvokeAsync(method, args);
    
            public Task AddConnectionIdToGroupAsync(string connectionId, string groupName) =>
                _hubContext.Groups.AddAsync(connectionId, groupName);
            // ...
        }
    }
