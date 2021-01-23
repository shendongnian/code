    public class HomeController : Controller
    {
        private readonly List<string> _myArray;
    
        public HomeController(IOptions<MySettings> mySettings)
        {
            _myArray = mySettings.Value.MyArray;
        }
    
        public IActionResult Index()
        {
            return Json(_myArray);
        }
    }
