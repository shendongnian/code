    using System.Web.Http;
    using MyData;
    
    namespace MyTestApp.Controllers
    {
        public class MyTestController : ApiController
        {
            private readonly IEmployeeRepository _employeeRepository;
            public MyTestController(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }
    
    
            public IHttpActionResult Get()
            {
                var employees = _employeeRepository.GetEmployees();
                return Ok(employees);
            }
        }
    }
