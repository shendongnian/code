    [Route("api/[controller]")]
    public class CoreController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return Json("Dev");
        }
    }
