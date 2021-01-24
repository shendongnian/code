    public void ConfigureServices(IServiceCollection services) {
        services.AddOptions();
    
        // ... 
        services.AddSingleton<ITableRepositories, TableClientOperationsService>();
    
        // Add framework services.
        services.AddOpenIdConnect(options => {
            // options.ClientId = ...
            options.Events = new OpenIdConnectEvents {
                OnTicketReceived = TicketReceived
            };
        });
    }
    private async Task TicketReceived(TicketReceivedContext context) {
        var user = (ClaimsIdentity)context.Principal.Identity;
        if (user.IsAuthenticated) {
            // ... 
            // get the ITableRepositories repository
            var repository = context.HttpContext.RequestServices.GetService<ITableRepositories>();
            var myUser = await repository.GetAsync<Connection>(userId);
            // ... 
        }
        return;
    }
