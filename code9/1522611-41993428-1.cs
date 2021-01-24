    public class MyController : ApiController {
    
        //POST api/XMLInput
        [Route("api/XMLInput")]
        [HttpPost]
        public IHttpActionResult PostXMLInput([FromBody] XmlDocument xml) {
            XMLInput xmlInput = new XMLInput();
            xmlInput.XML = xml.InnerXml;
            return null;
        }
    }
