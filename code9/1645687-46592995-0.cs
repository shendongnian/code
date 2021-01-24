    public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
    {
        return dependency.TargetType == typeof(ILogger);
    }
    public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
    {
        return new LoggerImpl.GetLogger(model.Implementation.FullName);
    }
