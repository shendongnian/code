    [RoutePrefix("api/front")]
    public class MyController : ApiController {
    
        [HttpGet]
        [Route("")] // matches GET api/front
        [ResponseType(typeof(SparePartsFrontDTO))]
        public async Task<IHttpActionResult> Get() {
            //...
        }
    
        [HttpGet]
        [Route("filter/{filter}")] // matches GET api/front/filter/anything-here
        [ResponseType(typeof(IEnumerable<SparePartSearchDTO>))]
        public async Task<IHttpActionResult> Get(string filter) {
            //...
        }
    
        [HttpGet]
        [Route("categories")] //matches GET api/front/categories
        [ResponseType(typeof(IEnumerable<DeviceCategoryDTO>))]
        public async Task<IHttpActionResult> GetCategories() {
            //...
        }
    }
