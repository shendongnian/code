    [RoutePrefix("api/product")] 
    public class ProductController : ApiController
    {
        [Route("{keywordSearch}")] 
        public IHttpActionResult Get(string keywordSearch)
    
        [Route("{id:long}")]
        public IHttpActionResult Get(long id)
    }
