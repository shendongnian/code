    public class CustomerController : Controller
    {
        private SampleDBContext _context;
    
        public CustomerController(SampleDBContext context)
        {
            _context = context;
        }
    
        public async Task<IActionResult> Index(int id)
        {
            var user = _context.Users.Where(i => i.Id == id).FirstOrDefault();
            ...
        }
    }
