    [Route("api/[controller]")]
    public class MeController : Controller {
        private readonly ITechRepository _tech;
        private readonly IPageOptions _page;
        public MeController(ITechRepository tech,IPageOptions page) {
            _tech = tech;
            _page = page;
        }
    
        //GET api/me/tech
        [HttpGet("tech")]
        public IEnumerable<TechStack> Get() {
            return _tech.getAll();
        }
    
        //GET api/me/options
        [HttpGet("options")]
        public IEnumerable<PageControl> getOptions() {
            return _page.getOptions();
        }
    
        //GET api/me/5
        [HttpGet("{id:int}")]
        public int Get(int id) {
            return id;
        }
    }
