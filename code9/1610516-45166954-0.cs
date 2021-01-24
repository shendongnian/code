    [RoutePrefix("api/v1/clients")]
    public class ClientsController : ApiController {
        //...other code removed for brevity
        
        [HttpGet]
        [Route("")] //Matches GET api/v1/Clients
        public IHttpActionResult Get() {
           //code
        }
        
        [HttpGet]
        [ResponseType(typeof(Client))]
        [Route("{id:int}")] //Matches GET api/v1/Clients/5
        public IHttpActionResult GetClientById(int id) {
            //code
        }
        
        [HttpGet]
        [ResponseType(typeof(string))]
        [Route("{id:int}/emailid")] //Matches GET api/v1/Clients/5/emailid
        public IHttpActionResult GetClientEmailId(int id) {
            //code
        }        
    }
