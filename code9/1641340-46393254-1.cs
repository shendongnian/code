    public class FileController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public FileController(IHostingEnvironment environment)
        {
            hostingEnvironment = environment;
        }
        [HttpPost]
        public IActionResult SaveFile(IFormFile logo)
        {
            if (logo != null)
            {
                //simply saving to "uploads" directory
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads, logo.FileName);
                logo.CopyTo(new FileStream(filePath, FileMode.Create));  
                return Json(new { status = "success" });              
            }
            return Json(new { status = "error" });
        }
    }
