    [Route("api/[controller].svc")]
    public class ServiceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(DateTimeOffset.Now);
        }
    }
