    [HttpPost]
    public ActionResult QuestionsAction()
    {
    QuestionsMasterModel objQuestionsMasterModel = new QuestionsMasterModel();
    objQuestionsMasterModel.QuestionsModelList = //Add your List of data here;
    
    return PartialView("QuestionsAction", objQuestionsMasterModel);
    }
