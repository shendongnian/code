    [RoutePrefix("api")]
    public class MyController : ApiController {
    
        //POST api/XMLInput
        [Route("XMLInput")]
        [HttpPost]
        public IHttpActionResult PostXMLInput([FromBody] XmlDocument xml) { ... }
    }
