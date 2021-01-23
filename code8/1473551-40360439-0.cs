    public void ExecuteCommand(ICommand command)
    {
        var handler = cqrsHandlerFactory.GetCommandHandler(command);
        // ...
    }
