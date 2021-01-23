    public class BootstrapConfig
    {
        public static void Register(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
            container.Install(               
                new DomainModelLayerInstall(),               
                new AutoMapperInstall()
            );
        }
    }
