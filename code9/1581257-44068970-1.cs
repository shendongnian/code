    [RoutePrefix("api/products")]
    public class ProductsController : ApiController {
    
        [HttpGet]
        [Route("{id:int}")] //Matches GET api/products/1
        public IHttpActionResult Get(int id) {
            return Ok(GetValueById(id));
        }
        
        [HttpPost]
        [Route("")] //Matches POST api/products
        public IHttpActionResult Post([FromBody]Product model) {
            //...code removed for brevity
        }
    
        [HttpPut]
        [Route("{id:int}")] //Matches PUT api/products/1
        public IHttpActionResult Put(int id, [FromBody]Product model) {
            //...code removed for brevity
        }
    
        [HttpDelete]
        [Route("{id:int}")] //Matches DELETE api/products/1
        public IHttpActionResult Post(int id) {
            //...code removed for brevity
        }
    }
