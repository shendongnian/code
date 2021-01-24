    [Produces("application/json")]
    [Route("api/MyController")]
    public class MyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DatasourceDataController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet()]
        public async Task<IActionResult> DoSometing()
        {
			...
			await _context.(...);
			...
        }
    }
