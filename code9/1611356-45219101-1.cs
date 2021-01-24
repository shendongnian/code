    public class CommonContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Common.Logger>(new ContainerControlledLifetimeManager());
        }
    }
