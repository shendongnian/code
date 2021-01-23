    using System.Web.Mvc;
    
    [RoutePrefix("sth/api/v1/files")]
    public class FilesController : Controller
    {
        [HttpPost]
        [Route("getcloudcontent")]
        public ActionResult CloudContent(string model)
        {
            return Content("test");
        }
    }
