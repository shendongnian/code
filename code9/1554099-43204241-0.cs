    public void Configuration(IAppBuilder app)
    {
        string connectionString = "<Service Bus connection string>";
        GlobalHost.DependencyResolver.UseServiceBus(new ServiceBusScaleoutConfiguration(connectionString, "FeHanSignalRChat") { TopicCount = 3 });
    
        app.MapSignalR();
    }
