    [Route("[controller]")] //Set the prefix for subsequent route attributes
    public class SurveyController : Controller
    {
        [Route("conditions")]
        public IActionResult GetConditions()
        {
            List<int> Conditions = new List<int{1};
            return View("Conditions",Conditions);
        }
    }
