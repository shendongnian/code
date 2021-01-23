    public void ExecuteCommand<TCommand>(TCommand command)
    {
        // You can merge the factory and your CqrsBus. Splitting them is useless.
        var handler = cqrsHandlerFactory.GetCommandHandler<TCommand>();
        // You don't need then null check; Autofac never returns null.
        handler.Handle(command);
    }
