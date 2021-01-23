    [Route("api/[controller]")]
    public class BoardController : Controller
    {
        private IDataContext dataContext;
    
        public BoardController(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    
        [Route("/[controller]/[action]")
        public IActionResult Index(int boardID)
        {
            return View();
        }
    
        [HttpGet]
        public IEnumerable<Board> GetAll()
        {
        }
    }
