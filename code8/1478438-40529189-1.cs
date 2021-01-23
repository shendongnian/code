    var userAnswers = new List(Answer);
    //populate your useranswers here
    foreach(var question in Questions)
    {
        var answersForQuestion = question.Answers.Select(a=>a.QuestionId == question.Id);
        if (userAnswers.FindAll(ua => ua.QuestionId == questionId).Length == question.Answers.Count())
        {
            //correct amount of answers. check for actual answers
            if (userAnswers.Any(ua => question.Answers.Contains(a=>a.Id == ua.Id))
        //correct answers made
        {
    }
        
