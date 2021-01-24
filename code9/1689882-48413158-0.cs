    class Program
    {
        // Declare your container as a static variable so it can be referenced later
        static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            // Assign the container to the static IContainer
            Container = BuildContainer();
            var employeeService = container.Resolve<EmployeeService>();
            Employee employee = new Employee
            {
                EmployeeId = 1,
                FirstName = "Peter",
                LastName = "Parker",
                Designation = "Photographer"
            };
            employeeService.Print(employee);
        }
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<EmployeeService>();
            return builder.Build();
        }
    }
