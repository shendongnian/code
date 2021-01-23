    [RoutePrefix("api/forum")]
    public class ForumController : Controller
    {
        private MainContext _context;
        public ForumController()
        {
            _context = new MainContext();
        }
        [HttpGet]
        public string Get()
        {
            return "string";
        }
    }
