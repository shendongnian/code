    [Route("api/demo")]
    public class Demo : Controller {
        //GET api/demo/info?x=34
        [HttpGet("Info")]
        public JsonResult GetInfos(string x) { ... }
    }
