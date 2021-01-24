    public class MyController : ApiController {
    
        //POST api/XMLInput
        [Route("api/XMLInput")]
        [HttpPost]
        public IHttpActionResult PostXMLInput([FromBody] XmlDocument xml) { ... }
    }
