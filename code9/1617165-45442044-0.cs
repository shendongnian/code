    internal class PropertyInjectionViewEngineDecorator : IViewEngine
    {
        private readonly ConcurrentDictionary<Type, Registration> registrations = new ConcurrentDictionary<Type, Registration>();
        private readonly IViewEngine decoratee;
        private readonly Func<Type, Registration> createRegistration;
        public PropertyInjectionViewEngineDecorator(IViewEngine decoratee, Container container)
        {
            this.decoratee = decoratee;
            this.createRegistration = type => Lifestyle.Transient.CreateRegistration(type, container);
        }
        public ViewEngineResult FindPartialView(ControllerContext context, string partialViewName, bool useCache) =>
            this.InitializeView(this.decoratee.FindPartialView(context, partialViewName, useCache));
        public ViewEngineResult FindView(ControllerContext context, string viewName, string masterName, bool useCache) =>
            this.InitializeView(this.decoratee.FindView(context, viewName, masterName, useCache));
        public void ReleaseView(ControllerContext controllerContext, IView view) =>
            this.decoratee.ReleaseView(controllerContext, view);
        private ViewEngineResult InitializeView(ViewEngineResult result)
        {
            if (result.View != null)
            {
                Registration registration = this.registrations.GetOrAdd(result.View.GetType(), this.createRegistration);
                registration.InitializeInstance(result.View);
            }
            return result;
        }
    }
