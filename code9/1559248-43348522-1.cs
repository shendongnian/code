    public class RuntimeDataSupportFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Resolver.AddSubResolver(new RuntimeDataDependencyResolver());
        }
    }
    public class RuntimeDataDependencyResolver : ISubDependencyResolver
    {
        private Type[] acceptedTypes = new[] { typeof(IDictionary<String, Object>) };
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            if (ReferenceEquals(dependency.TargetType, acceptedTypes[0])) // typeof(IDictionary<String, Object>
                return MvcApplication.GlobalStore;
            return null;
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
            if (acceptedTypes.Any(t => ReferenceEquals(t, dependency.TargetType)))
                return true;
            return false;
        }
    }
