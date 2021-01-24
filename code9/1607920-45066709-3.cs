    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ResolutionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddMvc();
        // Domain Event Handlers
        services.AddTransient<IEventHandler<RequestCreatedEvent>, RequestCreatedHandler>();
        // Domain Event Dispatcher
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        // Units of Work
        services.AddTransient<IResolutionUnitOfWork, ResolutionUnitOfWork>();
        // Commands and Queries
        services.AddTransient<ICommandHandler<CreateRequestCommand, Guid>, CreateRequestHandler>();
        // Command and Query Dispatcher
        services.AddSingleton<IDispatcher, Dispatcher>();
    }
