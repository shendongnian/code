    public class HomeController : Controller
    {
        private IFileServerProvider _fileServerProvider;
        public HomeController(IFileServerProvider fileServerProvider)
        {
            _fileServerProvider = fileServerProvider;
        }
        public IActionResult Index()
        {
            var fileProvider = _fileServerProvider.GetProvider("/MyPath");
            var fileInfo = fileProvider.GetFileInfo("MyFile.txt");
            using (var stream = System.IO.File.OpenRead(fileInfo.PhysicalPath))
            {
                string contents = new StreamReader(stream).ReadToEnd();
            }
            return View();
        }
    }
