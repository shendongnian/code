    [Route("api/v1/[controller]/[action]")]
    public class MyController : Controller
    {
        // GET: ~/api/v1/mycontroller/status
        [HttpGet]
        public JsonResult Status()
        {
            return Json(new { status = "API is running" });
        }
    }
