    [Produces("application/json")]
    [Route("api/Default/")]
    public class DefaultController : Controller {
        [HttpPost]
        public JsonResult apc([FromBody]Dictionary<string,string>[] data) {
            var value = data[0]["Question1"]; // Should be "Answer1"
            //Code Here
            return Json(true);
        }
    }
