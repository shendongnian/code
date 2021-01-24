    class Program
    {
        static private IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<SomeService>().As<ISomeService>();
            builder.RegisterType<PrintService>().As<IPrintService>();
            return builder.Build();
        }
        static public void Main()  //Main entry point
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
