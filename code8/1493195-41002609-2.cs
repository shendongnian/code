    public class GuideController : ApiController
    {
        [AcceptVerbs("GET")]
    
        [HttpGet]
        public IHttpActionResult Get()
        {
            Item item = Item.GetTestData();
            return Ok(item);
        }
    }
