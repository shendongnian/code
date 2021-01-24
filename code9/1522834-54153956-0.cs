    public class ProxyController : Controller
    {
        [ProxyRoute("api/Proxy/{name}")]
        public static Task<string> Get(string name)
        {
            return Task.FromResult($"http://www.google.com/");
        }
    }
