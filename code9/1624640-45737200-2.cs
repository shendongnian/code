    public class ProjectController : ApiController {
        //...other code removed for brevity
        [HttpGet]
        [Route("api/projects/archive/{id:int}")]//Matches GET api/projects/archive/1
        public IHttpActionResult Archive(int id) {
            _projectService.Archive(id);
            return Ok();
        }    
    }
