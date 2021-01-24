    public class ServiceRegister : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
        Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            SomeTypeRequiredByConstructor context = new SomeTypeRequiredByConstructor ();
            container.Register(
                Component
                    .For<IServiceToRegister>()
                    .ImplementedBy<ServiceToRegister>().
                 DependsOn(Dependency.OnValue<SelfServiceShopDatabaseContext>(context))//This is in case your service has parametrize constructoe
                    .LifestyleTransient());
        }
    }
