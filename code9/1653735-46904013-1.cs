     public ActionResult Index()
        {
            IList<ExamModel> lstModel = new List<ExamModel>();
            lstModel.Add(new ExamModel()
            {
                questionContent = "Test Question1",
                questionId = 1,
                answerId = 101,
                answerContent = "Answer Test101"
            });
            lstModel.Add(new ExamModel()
            {
                questionContent = "Test Question2",
                questionId = 2,
                answerId = 102,
                answerContent = "Answer Test102"
            });
            return View(lstModel);
        }
