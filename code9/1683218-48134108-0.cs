    [Route("[controller]")]
    public class ArticleController : Controller {
        //...other actions
    
        [HttpGet]
        [Route("FilterByTag/{tagId}")]
        public IActionResult FilterByTag(int tagId) {
            //...
    
            return View();
        }    
    }
