    [RoutePrefix("api/items")]
    public class ItemsController : ApiController
    {
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
