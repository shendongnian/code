    [RoutePrefix("api/PreviewLCAPI")]
    public class PreviewLCAPIController : ApiController {
    
        //GET api/PreviewLCAPI/5 <- only when the value is an int will it match.
        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetLCPreview(int id) { ... }
        
        //GET api/PreviewLCAPI/someone@email.com/
        [Route("{email}"]
        [HttpGet]
        [ResponseType(typeof(LCPreview))]
        public IHttpActionResult ValidateEmail(string email) { ... }
    }
