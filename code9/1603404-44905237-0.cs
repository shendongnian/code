    [RoutePrefix("api/employee")]
    public class EmployeeApiController : ApiController { // <-- Note: API controller
        [HttpGet]
        [Route("{id:long}")] //Match GET api/employee/5
        public IHttpActionResult GetEmployee(long id) { // <-- Note: return type
            var model = new Employee("Bobby", "Smedley",
                             "London", "Teheran",
                             EmployeeGender.M,
                             DepartmentCode.D_2157020,
                             "12345678901");
            return Ok(model);
        }    
    }
