    [RoutePrefix("api/v3/Company")]
    public class CompanyController : ApiController {
        //GET api/v3/Company
        [HttpGet]
        [Route("")] //Default Get
        public IQueryable GetEntities() { ... }
    
        //GET api/v3/Company/1f7dc74f-af14-428d-aa31-147628e965b2
        [HttpGet]
        [Route("{id:guid}")] // ALSO NOTE THAT THE PARAMETER NAMES HAVE TO MATCH
        public Task<IHttpActionResult> GetEntity(Guid id) { ... }
    
        //...other code removed for brevity
    }
