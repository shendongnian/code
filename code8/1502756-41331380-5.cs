    public class HomeController : Controller
    {
        private readonly MySettings _mySettings;
    
        public HomeController(IOptions<MySettings> mySettings)
        {
            _mySettings = mySettings.Value;
        }
    
        public IActionResult Index()
        {
            return Json(_mySettings.MyArray);
        }
    }
