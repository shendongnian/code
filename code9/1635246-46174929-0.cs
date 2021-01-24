    public class QuestionsController : Controller
    {
        private QuestionService _questionService = new QuestionService();
    
        [HttpGet]
        public JsonResult Index()
        {
            return Json(_questionService.ReadFile());
        }
    }
