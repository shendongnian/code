    public class DemoController : ApiController {
        [HttpPost]
        [Route("api/Demo/{id:int}/{e}/{o:bool}")] //Matches POST api/Demo/5/a/false
        public IHttpActionResult Post(int id, string e, bool o) {
            return Ok();
        }
    }
