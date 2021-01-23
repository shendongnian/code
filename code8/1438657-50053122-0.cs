    [Route("api/Documents")]
    public class DocumentsController : Controller
    {
        [Route("SendDocument")]
        [HttpPost]
        public ActionResult SendDocument([FromBody]DocumentDto document)
        {
            return Ok();
        }
    }
