    [Route("api/[controller]")]
    public class ProxyController : Controller
    {
        [ProxyRoute("{name}")]
        public static Task<string> Get(string name)
        {
            return Task.FromResult($"http://www.google.com/");
        }
    }
