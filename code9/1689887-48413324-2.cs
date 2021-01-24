    static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
        builder.RegisterType<EmployeePrinter>().As<IEmployeePrinter>();
        builder.RegisterType<SomeEmployeeFormatter>().As<IEmployeePrintFormatter>();
        builder.RegisterType<EmployeeService>();
        return builder.Build();
    }
