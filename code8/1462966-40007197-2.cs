    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new List<string> { "some results collection" });
        }
        [Route("names")]
        public IHttpActionResult GetByName([FromUri]string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("name is empty");
            }
            return Ok("some result");
        }
    
        [Route("updates")]
        public IHttpActionResult GetUpdates([FromUri]string updated = null)
        {
            if (string.IsNullOrWhiteSpace(updated))
            {
                return BadRequest("updated is empty");
            }
            return Ok("some result");
        }
    }
