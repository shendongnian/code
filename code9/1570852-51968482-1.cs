    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Cleaner>().As<ICleaner>();
            builder.RegisterType<Repository>().AsImplementedInterfaces().InstancePerLifetimeScope();
            
            // Add the MainWindowclass and later resolve
            build.RegisterType<MainWindow>().AsSelf();
    
            var container = builder.Build();
    
            using (var scope = container.BeginLifetimeScope())
            {
                var main = scope.Resolve<MainWindow>();
                main.ShowDialog();
            }
        }
    }
