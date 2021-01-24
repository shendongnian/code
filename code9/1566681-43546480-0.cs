    List<Question> QuestionList = new List<Question>
    {
        new Question{ Theme = "Sport", Author = "Tyler", T = "Question", },
        new Question{ Theme = "History", Author = "Tyler", T = "Question", },
        new Question{ Theme = "Sport", Author = "Tyler", T = "Question", },
    };
    
    var HistoryCount = QuestionList.Count(x => x.Theme == "History");
    var SportCount = QuestionList.Count(x => x.Theme == "Sport");
