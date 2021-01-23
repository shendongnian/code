    Survey survey = db.Surveys.Find(id);
    if (survey == null) // check for null here
    { 
        return HttpNotFound(); 
    } 
    IEnumerable<Area> areas = db.Areas;
    SurveyResponseVM model = new SurveyResponseVM()
    {
        ID = survey.ID,
        SelectedArea = survey.AreaID,
        .... // other properties of Survey as required for the view
        AreaList = new SelectList(areas , "ID", "SubLevel"),
        Questions = survey.Answers.Select(x => new QuestionVM() 
        {
            QuestionText = x.Question.QuestionText, 
            AnswerID = x.ID, 
            Response = x.Response 
        }) 
    };
    return View(model);
