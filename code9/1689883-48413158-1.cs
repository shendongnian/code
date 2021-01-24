    public void Print(Employee employee)
    {
            // Create the scope, resolve your EmployeeRepository,
            // use it, then dispose of the scope.
            using (var scope = Container.BeginLifetimeScope())
            {
                var repository = scope.Resolve<IEmployeeRepository>();
                repository.Update(employee);
            }
    }
