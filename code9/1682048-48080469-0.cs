    [Route("[controller]"]
    public class CasesController : Controller {
    
        //Matches GET cases/search/volvo
        [HttpGet]
        [Route("search/{q}")]
        public IActionResult Search(string q) {
            //...code removed for brevity
        }
    
    }
