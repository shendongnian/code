    [ExcludeFromCodeCoverage]
    static class Program
    {
        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Application>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            builder.RegisterType<PrintService>().As<IPrintService>();
            return builder.Build();
        }
        public static void Main()  //Main entry point
        {
            CompositionRoot().Resolve<Application>().Run();
        }
    }
