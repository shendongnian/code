    class LayersResolver : ISubDependencyResolver
    {
        public LayersResolver(IKernel kernel)
        {
            _kernel = kernel;
        }
        public bool CanResolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType == typeof(ILayer[]);
        }
        public object Resolve(CreationContext context, ISubDependencyResolver contextHandlerResolver, ComponentModel model,
            DependencyModel dependency)
        {
            var result = _kernel.GetAssignableHandlers(typeof (ILayer))
                                .Where(h => h.ComponentModel.Name.StartsWith(model.Name))
                                //at this point it is not clear to me, whether I should call 
                                //h.Resolve(context)
                                //or
                                //h.Resolve(context, contextHandlerResolver, model, dependency)
                                //or
                                //_kernel.Resolve<ILayer>(h.ComponentModel.Name)
                                //and what is the difference
                                .Select(h => h.Resolve(context))
                                .Cast<ILayer>()
                                .ToArray();
            return result;
        }
        private readonly IKernel _kernel;
    }
