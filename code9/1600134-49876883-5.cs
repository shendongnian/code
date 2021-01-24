    [Route("Anonymous")]
    public class AnonymousController : Controller
    {
        [HttpGet("Echo")]
        public string Echo(string data)
        {
            return data;
        }
    }
