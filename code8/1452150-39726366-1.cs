    container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
    
    container.Options.LifestyleSelectionBehavior = new WebApiInjectionLifestyle();
    internal class WebApiInjectionLifestyle : ILifestyleSelectionBehavior
    {
        public Lifestyle SelectLifestyle(Type serviceType, Type implementationType)
        {
            return Lifestyle.Scoped;
        }
    }
