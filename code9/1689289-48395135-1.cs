    public class MyHub : Hub
    {
    }
    
    public class CallingSideClass
    {
        private readonly IHubContext<MyHub> _hubContext;
    
        public CallingSideClass(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }
    
        public async Task FooMethod(...)
        {
            await _hubContext.Clients.All.InvokeAsync(...);
        }
    }
    public class Startup
    {...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddScoped<CallingSideClass>();
        }
        ... 
    }
