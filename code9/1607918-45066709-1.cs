    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ResolutionDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        services.AddMvc();
        // Domain Event Handlers
        services.AddTransient<IEventHandler<RequestCreatedEvent>, RequestCreatedHandler>();
        // Build providers
        var domainEventServiceProvider = services.BuildServiceProvider();
        // Domain Event Dispatcher
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>(d => new DomainEventDispatcher(domainEventServiceProvider));
        // Units of Work
        services.AddTransient<IResolutionUnitOfWork, ResolutionUnitOfWork>();
        // Commands and Queries
        services.AddTransient<ICommandHandler<CreateRequestCommand, Guid>, CreateRequestHandler>();
        // Build providers
        var cqrsServiceProvider = services.BuildServiceProvider();
        // Command and Query Dispatcher
        services.AddSingleton<IDispatcher, Dispatcher>(d => new Dispatcher(cqrsServiceProvider));
    }
