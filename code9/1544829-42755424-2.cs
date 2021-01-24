    public class TestController : BaseController
                                //^^^^^^^^^^^^^^
    {
        private ProjNameContext _context;
    
        public TestController(ProjNameContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public IActionResult TestAction()
        {
            Now you don't need to cache the username yourself as it's done for you.
            var username = Username;
            //Do something with username
        }
    
    }
