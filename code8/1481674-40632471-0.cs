    Question questionObj = new Question();
    questionObj.CreatedBy = "Test";
    questionObj.CreatedDate = DateTime.Now;
    QuestionRespons questionResponsesObj = new QuestionRespons();
    // fill question response here
    questionObj.QuestionResponses.Add(questionResponseObj);
    testEntity.Questions.Add(questionObj);
    testEntity.SaveChanges();
