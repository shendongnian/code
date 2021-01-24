    public class XModule : Module
    {
        public XModule()
        {
            this._generator = new ProxyGenerator();
        }
        private readonly ProxyGenerator _generator;
        protected override void AttachToComponentRegistration(
            IComponentRegistry componentRegistry, 
            IComponentRegistration registration)
        {
            if (registration.Services
                            .OfType<IServiceWithType>()
                            .Any(s => s.ServiceType == typeof(IApplicationService)))
            {
                registration.Activating += Registration_Activating;
            }
        }
        private void Registration_Activating(Object sender, ActivatingEventArgs<Object> e)
        {
            Object proxy = this._generator.CreateClassProxyWithTarget(
                e.Instance.GetType(),
                e.Instance,
                e.Context.Resolve<IEnumerable<IInterceptor>>().ToArray());
            e.ReplaceInstance(proxy);
        }
    }
