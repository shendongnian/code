    public class EmployeeController : ApiController {
        private readonly IEmployeeService employeeService;
    
        public EmployeeController(IEmployeeService service) {
            this.employeeService = service;
        }
    
        [HttpPost]
        public HttpResponseMessage AddEmployee(Employee emp) {
            try {
                employeeService.AddEmployee(emp);
                return Request.CreateResponse(HttpStatusCode.Created, emp);
            } catch(Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    
        //...other actions.
    }
