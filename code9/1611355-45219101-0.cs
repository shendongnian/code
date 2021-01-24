    public class RegistrationManager : IRegistrationManager
    {
        private IUnityContainer container;
        public RegistrationManager(IUnityContainer container)
        {
            this.container = container;
        }
        public void RegisterCommon()
        {
            this.container.RegisterType<Common.Logger>(new ContainerControlledLifetimeManager());
        }
    }
