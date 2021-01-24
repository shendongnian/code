    public class InjectIdSubDependencyResolver : ISubDependencyResolver
    {
        private const string SpecialName = "id";
        public bool CanResolve(
            CreationContext context, ISubDependencyResolver contextHandlerResolver, 
            ComponentModel model, DependencyModel dependency) 
            => 
            dependency.TargetType == typeof(string)
            &&
            dependency.DependencyKey == SpecialName
            &&
            dependency.Parameter?.ConfigValue == null;
        public object Resolve(
            CreationContext context, ISubDependencyResolver contextHandlerResolver, 
            ComponentModel model, DependencyModel dependency) 
            => model.Name;
    }
