    public class SessionInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Component.For<YourDbContext>().UsingFactoryMethod(() => MvcApplication.CurrentContext)
                    .LifeStyle
                    .PerWebRequest);
        }
    }
