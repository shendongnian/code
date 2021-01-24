    [RoutePrefix("api/somepath")]
    public class MyController : ApiController {
    
        //Matches GET api/somepath/5
        [HttpGet]
        [Route("{id:int}")]
        public int GetByID(int id) {
            return id;
        }
    
        //Matches GET api/somepath/neil
        [HttpGet]
        [Route("{name}")]
        public string GetByName(string name) {
            return name;
        }
    }
