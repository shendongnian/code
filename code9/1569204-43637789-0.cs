    var dict = new Dictionary<string,object>();
    dict["FirstName"] = objReturn.FirstName;
    dict["LastName"] = objReturn.LastName;
    foreach (var answerobj in objReturn.SurveyAnswers)
    {
        // it's not entirely clear where you are getting the JSON
        // property names from, but assuming `QuestionText` gives you the property name
        // Otherwise, adjust as necessary...
        dict[answerObj.QuestionText] = answerObj.AnswerText;
    }
