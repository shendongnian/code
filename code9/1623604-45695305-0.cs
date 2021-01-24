    public class ProjectSpecification {
        public int CustomerId { get; set; }
        //...other properties
    }
    public class ProjectsController : ApiController {
        [HttpGet]
        public IHttpActinoResult GetProjects([FromUri]ProjectSpecification projectSpecification) {
            return Ok(projectSpecification);
        }
    }
