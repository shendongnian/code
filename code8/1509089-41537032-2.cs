    [RoutePrefix("api/EmployeeApi")]
    public class EmployeeApiController : ApiController
    {
        //GET api/EmployeeApi
        [HttpGet]
        [Route("")]
        public List<Student> GetAllStudents() { ... }
        //GET api/EmployeeApi/EmailChange/foo/foo@email.com
        [HttpGet]
        [Route("EmailChange/{studentName}/{email}")]
        public List<Student> EmailChange(string studentName, string email) { ... }
        //GET api/EmployeeApi/AddressChange/foo/China
        [HttpGet]
        [Route("AddressChange/{studentName}/{address}")]
        public List<Student> AddressChange(string studentName, string Address) { ... }
    }
