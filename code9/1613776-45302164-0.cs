    public class LoggerResolver : ISubDependencyResolver
    {
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return dependency.TargetType == typeof(ILogger);
        }
    
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            return new LogManager.GetLogger(model.Implementation.FullName);
        }
    }
