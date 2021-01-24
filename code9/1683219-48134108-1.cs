    [Route("[controller]")]
    public class ArticleController : Controller {
        //...other actions
    
        [HttpGet]
        [Route("FilterByTag/{tagId}")] // Matches GET Article/FilterByTag/2
        public IActionResult FilterByTag(int tagId) {
            //...
    
            return View();
        }    
    }
