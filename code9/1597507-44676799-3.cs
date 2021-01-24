    public interface IAddPersonCommand {
        int? InsertRecord(Models.Person model model);
    }
    public class PersonController : ApiController {
        private readonly IAddPersonCommand service;
        public PersonController(IAddPersonCommand service) {
            this.service = service;
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody]Models.Person model) {    
            if (ModelState.IsValid) {
                var id = service.InsertRecord(model);
                if(id !=null) {
                    return Ok(id);
                }
            } 
            //If we get this far bad request
            return BadRequest();
        }
    }
