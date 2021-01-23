    public class CqrsBus : ICqrsBus
    {
        private readonly IComponentContext context;
        public CqrsBus(IComponentContext context)
        {
            this.context = context;
        }
        public void ExecuteCommand(ICommand command)
        {
            Type handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = this.context.Resolve(handlerType);
            void handler.Execute((dynamic)command);
        }
    }
