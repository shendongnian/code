    [RoutePrefix("api/windows")]
    public class WmsController : ApiController
    {
        [HttpGet]
        [Route("hi")]
        public IHttpActionResult Hello()
        {
            return Ok("Welcome to my Api.");
        }
    
    }
