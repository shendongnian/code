    public class AutoMapperInstall : Castle.MicroKernel.Registration.IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Castle.MicroKernel.Registration.Component.For<IMapper>().UsingFactoryMethod(factory =>
            {
                return new MapperConfiguration(map =>
                {
                    map.AddProfile<AutoMapperProfile>();
                }).CreateMapper();
            }));
        }
    }
