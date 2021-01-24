    [Route("api/demo")]
    public class DemoController : Controller
    {
        IHubContext<ChatHub, ITypedHubClient> _chatHubContext;
        public DemoController(IHubContext<ChatHub, ITypedHubClient> chatHubContext)
        {
            _chatHubContext = chatHubContext;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _chatHubContext.Clients.All.BroadcastMessage("test", "test");
            return new string[] { "value1", "value2" };
        }
    }
