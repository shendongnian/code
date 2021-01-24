    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            var surveys = new List<int>{1};
            return View(Surveys);
        }
    
        [HttpGet("conditions")]
        public IActionResult conditions()
        {
            List<int> Conditions = new List<int{1};
            return View();
        }
    }
