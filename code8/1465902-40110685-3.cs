    [RoutePrefix("AppartmentCategory")]
    public class AppartmentCategoryController : ApiController
    {
        //GET AppartmentCategory/043F61D1-7194-E611-A98B-9C5C8E0005FA VIA CONVENTION-BASED ROUTING
        [HttpGet]
        public IHttpActionResult Get(Guid uid){...}
        //GET AppartmentCategory/2fdc968d-0192-e611-a98b-9c5c8e0005fa VIA ATTRIBUTE ROUTING    
        [HttpGet]
        [Route("{propertyUid?}")]
        public IHttpActionResult GetList(Guid propertyUid){...}
    }
