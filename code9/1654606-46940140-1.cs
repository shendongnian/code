    [Route("")]
    public class StoryController : Controller
    {
        [Route("{id}")]
        public ActionResult Index(string id)
        {
            if(id =="some-id"){
            }
           return View();
        }
    }
