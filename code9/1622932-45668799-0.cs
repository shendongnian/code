    var types = container.GetTypesToRegister(typeof(ICommandHandler<>),
        new[] { typeof(ICommandHandler<>).Assembly },
        new TypesToRegisterOptions { IncludeGenericTypeDefinitions = true });
    container.Register(typeof(ICommandHandler<>),
        types.Where(t => !t.IsGenericTypeDefinition));
    foreach (Type type in types.Where(t => t.IsGenericTypeDefinition))
    {
        container.Register(typeof(ICommandHandler<>), type);
    }
