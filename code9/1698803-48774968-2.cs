     // GET: Question
        public ActionResult Index()
        {
            EventCompanyQuestionnaireQuestions model = new EventCompanyQuestionnaireQuestions
            {
                CompanyID = 1,
                EventID = 2,
                Questions = new List<Question>
                {
                    new Question {    QuestionID = 1,   Selected = false,  Title= "What is your name"  },
                    new Question {    QuestionID = 2,   Selected = false,  Title= "How old are you"  },
                    new Question {    QuestionID = 3,   Selected = false,  Title= "Where are you from"  },
                    new Question {    QuestionID = 4,   Selected = false,  Title= "What is your profession"  },
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EventCompanyQuestionnaireQuestions model)
        {
            var ids = model.Questions.Where(q => q.Selected).Select(q => q.QuestionID).ToList();
            
            if(ids!=null && ids.Any())
            {
                foreach (var id in ids)
                    Debug.WriteLine(id);
            }
            return View();
        }
