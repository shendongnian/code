    [RoutePrefix("api/listing")]
    public class ListingController : ApiController {
        //GET api/listing
        [HttpGet]
        [Route("")]
        public IEnumerable<ListItem> Get() { return Get(100, 12);  }
        //GET api/listing/2
        //GET api/listing/2/5
        [HttpGet]
        [Route("{firstparam:int}/{nextparam:int?}")]
        public IEnumerable<ListItem> Get(int firstparam, int nextparam = 12) { ... }
    }
