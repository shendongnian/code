    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public long Get() => DateTimeOffset.Now.ToUnixTimeSeconds();
    }
