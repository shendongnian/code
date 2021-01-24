    [Route("api/teacher")]
    public class TeacherController : Controller {
        // GET: api/Teacher/5
        [HttpGet("{id}", Name = "GetTeacher")]
        public IActionResult Get(int id) {
            //...
        }
    }
    [Route("api/school")]
    public class SchoolController : Controller
    {
        // GET: api/school/5
        [HttpGet("{id}", Name = "GetSchool")]
        public IActionResult Get(int id) {
            //...
        }
    }
