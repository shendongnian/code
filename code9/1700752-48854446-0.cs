    public static void RegisterTypes(IUnityContainer container)
    {
        //Add this line
         GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
           container.RegisterType<IEmployeeService, EmployeeService>();
           container.RegisterType<IRepository<Employee>, Repository<Employee>>();
    }
