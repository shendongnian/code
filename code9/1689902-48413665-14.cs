    [ExcludeFromCodeCoverage]
    static class Program
    {
        static private IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<PrintService>().As<IPrintService>();
            return builder.Build();
        }
        static public void Main()  //Main entry point
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
