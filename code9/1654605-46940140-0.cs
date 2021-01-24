    [Route("")]
    public class StoryController : Controller
    {
        [HttpGet("{id}")]
        public ActionResult Index(string id)
        {
            if(id =="some-id"){
            }
           return View();
        }
    }
