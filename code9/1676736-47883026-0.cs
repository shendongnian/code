        [HubAuthorizationAttribute]
        [HubName("printerHub")]
        public class PrinterHub : Hub
        {
            private static IHubContext hubContext =
                GlobalHost.ConnectionManager.GetHubContext<PrinterHub>();
    
        
            private IdentityInstance _userInstanceContext;
            private User _user;
            public override Task OnConnected()
            {
                //Custom logic to return a User object
                _userInstanceContext = new IdentityInstance(this.Context.User as ClaimsPrincipal);
                _user = _userInstanceContext.Create();
                return base.OnConnected();
            }
            public override Task OnDisconnected(bool stopping)
            {
                return base.OnDisconnected(stopping);
            }
            public async Task JoinPrinterNotifications()
            {
                await hubContext.Groups.Add(Context.ConnectionId, _user.ClientName + ":Printers");
            }
            public async Task PrintQueues(IEnumerable<QueuedPrintItem> items)
            {
                await hubContext.Clients.Group(_user.ClientName + ":Printers").notify(items);
            }
