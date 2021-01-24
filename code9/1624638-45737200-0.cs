    public class ProjectController : ApiController {    
        [HttpGet]
        [Route("api/projects/archive/{id:int}")]//Matches GET api/projects/archive/1
        public IHttpActionResult Archive(int id) {
            _projectService.Archive(id);
            return Ok();
        }    
    }
