    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Cleaner>().As<ICleaner>();
            builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            
            // Add the App class and later resolve
            build.RegisterType<App>().AsSelf();
    
            var container = builder.Build();
    
            using (var scope = container.BeginLifetimeScope())
            {
                App app = container.Resolve<App>();
                app.InitializeComponent();
                app.Run();
            }
        }
    }
