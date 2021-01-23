    [RoutePrefix("api/listing")]
    public class ListingController : ApiController {
        //GET api/listing
        //GET api/listing?firstparam=x
        //GET api/listing?nextparam=y
        //GET api/listing?firstparam=x&nextparam=y
        [HttpGet]
        [Route("")]
        public IEnumerable<ListItem> Get(int firstparam = 100, int nextparam = 12) { ... }
    }
