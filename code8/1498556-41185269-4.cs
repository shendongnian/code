    public class AutofacConfig
    {
        private static IContainer _container;
        public static Action<ContainerBuilder> OverridenRegistrations;
        public static IContainer Container
        {
            get { return _container; }
        }
        public static void IoCConfiguration()
        {
            var builder = new ContainerBuilder();
            // Registrations...
            builder.RegisterType<AThing>();
            builder.RegisterType<Foo>().AsImplementedInterfaces();
            
            OverridenRegistrations(builder);
            _container = builder.Build();
        }
    }
