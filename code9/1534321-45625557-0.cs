    public class Command : IRequest { ... }
    public class CommandHandler : IAsyncRequestHandler<Command> { ... }
    services.AddTransient<IPipelineBehavior<Command,Unit>, MyBehavior<Command,Unit>>();
    
    
