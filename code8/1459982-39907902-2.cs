    [Route("v1/[controller]/")]
    public class ThingController : Controller
    {
        [HttpGet("ById/{id}")]
        [Produces(typeof(ThingDTO))]
        public async Task<IActionResult> GetThing([FromRoute] long id)
        {
            // Your implementation
        }
    }
