    [RoutePrefix("ThisAction")]
    public class ThisActionController : Controller {
        [HttpGet]
        [Route("")] //Matches GET ThisAction
        public ActionResult Index() {
            //...
        }
        [HttpGet]
        [Route("{programId:int}")] //Matches GET ThisAction/123
        public ActionResult Index(int programId) {
            //...
        }
        [HttpGet]
        [Route("{programKey}")] //Matches GET ThisAction/ABC
        public ActionResult Index(string programKey) {
            //...
        }    
    }
