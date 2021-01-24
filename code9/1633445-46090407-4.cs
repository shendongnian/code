    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace MVCDragDrop.Controllers
    {
        public class HomeController : Controller
        {
            private AmazonS3Uploader amazonS3;
            public HomeController()
            {
                amazonS3 = new AmazonS3Uploader();
            }
            // GET: Home
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult UploadFiles(IEnumerable<HttpPostedFileBase> files)
            {
                List<string> paths = new List<string>();
                foreach (var file in files) {
                    string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    string destPath = Path.Combine(Server.MapPath("~/UploadedFiles"), filePath);
                    paths.Add(destPath)
                    file.SaveAs(destPath);
                }
                foreach(var path in paths){
                    amazonS3.UploadFile(path);
                }
                return Json("file uploaded successfully");
            }
        }
    }
        
