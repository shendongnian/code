    public class AppointmentsController : Controller
    {
        private ApplicationDbContext _context;
    
        public AppointmentsController()
        {
            _context = new ApplicationDbContext("DataBasConnection");
        }
    }
