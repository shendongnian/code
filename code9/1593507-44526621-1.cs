    public class TestController : Controller
        {
            public ActionResult Test()
            {
                var model = new CurrentViewModel()
                {
                    Questions = new List<SelectListItem>()
                    {
                        new SelectListItem()
                        {
                            Text = "Question 1",
                            Value = "Question 1"
                        },
    
                        new SelectListItem()
                        {
                            Text = "Question 2",
                            Value = "Question 2"
                        }
                    },
                    Answers = new List<string>()
                };
    
                return View("Test", model);
            }
    
            public PartialViewResult GetAnswers(CurrentViewModel model)
            {
                model.Answers = new List<string>();
                //model.Answers = Get Answers from some service?!
                model.Answers.Add("Answer 1");
                model.Answers.Add("Answer 2"); //Add manuall for example
                return PartialView("_Answers", model);
            }
    
            public PartialViewResult AddAnswer(CurrentViewModel model)
            {
                model.Answers.Add("Add answer here...");
                return PartialView("_Answers", model);
            }
    
            public ActionResult SaveQuestionsAndAnswers(CurrentViewModel model)
            {
                if (model.Questions.Count == 0)
                {
                    
                }
    
                return View("Test", model);
            }
    
        }
