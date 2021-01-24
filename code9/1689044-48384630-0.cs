    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            var surveys = new List<int>{1};
            return View(Surveys);
        }
    
        [HttpGet("conditions")]
        [Route("Survey/conditions")]
        public IActionResult GetConditions()
        {
            List<int> Conditions = new List<int{1};
            return View();
        }
    }
