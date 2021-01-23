    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            foreach (var connection in Properties.Settings.Default.ServicedDBs)
            {
               container.Register(
                   Component.For<IService>()
                            .ImplementedBy<Service>()
                            .DependsOn(Dependency.OnValue("connectionString", connection)
                            .Named(connection)));
            }
        }
    }
