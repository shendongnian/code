    public class CrudController : Controller
    {
        [HttpPost]
        public JsonResult generateFiles(String name)
        {
            return Json(generateHtml(name));
        }
    }
