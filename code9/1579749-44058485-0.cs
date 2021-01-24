    public class SimpleInjectorAsyncScopeFilterAttribute : JobFilterAttribute, IServerFilter
    {
        private static readonly AsyncScopedLifestyle lifestyle = new AsyncScopedLifestyle();
    
        private readonly Container _container;
    
        public SimpleInjectorAsyncScopeFilterAttribute(Container container)
        {
            _container = container;
        }
    
        public void OnPerforming(PerformingContext filterContext)
        {
            AsyncScopedLifestyle.BeginScope(_container);
        }
    
        public void OnPerformed(PerformedContext filterContext)
        {
            var scope = lifestyle.GetCurrentScope(_container);
            if (scope != null)
                scope.Dispose();
        }
    }
