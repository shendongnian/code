     public class FileUploadViewModel
        {
            [Required]
           public HttpPostedFileBase File { get; set; }
            //Other Model Property
        }
        public class FileUploadMutipleController : Controller
        {
            //
            // GET: /FileUploadMutiple/
    
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public ActionResult AttachFiles(IEnumerable<FileUploadViewModel> attachments)
            {
                //Do other stuffs
                return View();
            }
            [HttpPost]//For generating multiple file attachment
            public ActionResult GetFile()
            {
                return PartialView("~/Views/FileUploadMutiple/_File.cshtml", new FileUploadViewModel());
            }
        }
