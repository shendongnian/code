    using System.Web.Mvc;
    
    namespace Controllers
    {
        [RoutePrefix("sth/api/v1/files")]
        public class FilesController : Controller
        {
            [Route("")]
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            [Route("getcloudcontent")]
            public ActionResult CloudContent(string model)
            {
                return Content("test");
            }
        }
    }
