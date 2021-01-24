    public class EmployeeController : ApiController
        {
            #region Call service
            private readonly IEmployeeServices _employeeServices;
            public EmployeeController(IEmployeeServices employeeServices)
            {
                _employeeServices = employeeServices;
            }
    
            readonly IEmployeeServices employeeServices = new EmployeeServices();
    
            public EmployeeController()
            {
                _employeeServices = employeeServices;
            }
    }
