    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        public PersonController(ApplicationDbContext sampleODataDbContext)
        {
            _appDbContext = sampleODataDbContext;
        }
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_appDbContext.Persons.AsQueryable());
        }
    }
