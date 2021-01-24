    public class ContainerConfig
    {
        public IContainer ConfigureAutofac()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ModelModule());
            return containerBuilder.Build();
        }
    }
