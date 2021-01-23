    public class UnityResolver : ISubDependencyResolver
    {
        public UnityResolver(UnityContainer container)
        {
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
           // Check if the Unity container can resolve it
           throw new NotImplementedException();
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model, DependencyModel dependency)
        {
           // Retrieve the dependency out of the unity controller
         throw new NotImplementedException();
        }
    }
