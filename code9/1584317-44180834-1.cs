    public class MyController : Controller
    {
        private IHostingEnvironment _env;
    
        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }
    
        public IActionResult Index()
        {
            var webRoot = _env.WebRootPath;
            var appData = System.IO.Path.Combine(webRoot, "files");
    
            var models = Directory.EnumerateFiles(appData).Select(x => new imagesviewmodel
    		{
    			Url = Url.Content(x)
    		});
    
            return View(models);
        }
    }
