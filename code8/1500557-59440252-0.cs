    public class StartEngine
    {
        public StartEngine(...params...)
        {
        }
    }
    public class StartEngineHandler : ICommandHandler<StartEngine>
    {
        public StartEngineHandler(...params...)
        {
        }
        
        public async Task Handle(StartEngine command)
        {
            // Start engine logic
        }
    }
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container container;
        public CommandDispatcher(Container container) => this.container = container;
        public async Task Dispatch<T>(T command) =>
            await container.GetInstance<ICommandHandler<T>>().Handle(command);
    }
    // Client code
    await dispatcher.Dispatch(new StartEngine(params, to, start, engine));
