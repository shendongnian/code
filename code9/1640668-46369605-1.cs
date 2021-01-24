    namespace ZebraCRM.API2.Controllers
    {
        [Route("api/[controller]")]
        public class LeadsController : Controller
        {
            private readonly ApplicationDbContext _context;
    
            public LeadController()
            {
                _context = new ApplicationDbContext();
            }        
    
            // POST api/values
            [HttpPost]
            public void Post(Lead formData)
            {
                formData.DateCreated = DateTime.Now;        
                _context.Lead.Add(formData);
                _context.SaveChanges();
            }
        }
    }
