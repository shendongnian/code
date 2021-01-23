    Question questionObj = new Question();
    questionObj.CreatedBy = "Test";
    questionObj.CreatedDate = DateTime.Now;
    QuestionRespons questionResponsesObj = new QuestionRespons();
    // fill question response here
    questionObj.QuestionResponses.Add(questionResponseObj);
    Response responseObj = new Response();
    // fill your response here
    questionResponsesObj.Response = reponseObj;
    // if you do the above in your loop you should be fine
    testEntity.Questions.Add(questionObj);
    testEntity.SaveChanges();
