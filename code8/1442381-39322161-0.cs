    public class ProfileController : Controller {
        private IHostingEnvironment _hostingEnvironment;
    
        public ProfileController(IHostingEnvironment environment) {
            _hostingEnvironment = environment;
        }
    
        [HttpPost]
        public async Task<IActionResult> Upload(IList<IFormFile> files) {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            foreach (var file in files) {
                if (file.Length > 0) {
                    var filePath = Path.Combine(uploads, file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return View();
        }
    }
