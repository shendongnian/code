    [Produces("application/json")]
    [Route("[controller]")]
    public class DefaultController : Controller
    {
        [Route("getUser")]
        public IActionResult GetUsers()
        {
             return Ok();
        }
    }
