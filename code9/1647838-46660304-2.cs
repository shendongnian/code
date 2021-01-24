    public class HomeController : Controller
    {
        public ApplicationDbContext _context;
    
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        ...        
    } 
