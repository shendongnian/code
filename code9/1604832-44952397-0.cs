    <img src="@Url.Action("ImageFromPath", new { filename = "1.jpg" })" />
    
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
    
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
    
        public ActionResult ImageFromPath(string filename)
        {
            string path = _hostingEnvironment.WebRootPath + "/img/" + filename;
            ...
        }
    }
