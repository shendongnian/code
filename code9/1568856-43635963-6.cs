    public class CompanyController : Controller
    {
        // This import is needed for using the 'Include' method.
        using Microsoft.EntityFrameworkCore;
        private ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Company> viewModelData = _context.Companies.Include(p => p.Contacts).ToList();
            
            return View(viewModelData);
        }
    }
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Promo { get; set; } // Yes or No field
        public List<Contact> Contacts { get; set; }
        public class Contact
        {
            [Key]
            public int ContactID { get; set; }
            public int CompanyID { get; set; }
            public string ContactName { get; set; }
            public string ContactNumber { get; set; }
        }
    }
