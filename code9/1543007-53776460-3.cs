    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger _logger;
    
        public ValuesController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValuesController>();
        }
    
        // POST api/values
        [HttpPost]
        public void Post([FromBody, NoLog]string value)
        {
            
        }
    
        [HttpPost]
        [Route("user")]
        public void AddUser(string id, [FromBody]User user)
        {
            
        }
    }
