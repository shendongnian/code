    var questions = new List<Question>
    {
       new QuestionA { Id = 1, OptionA = true, Text = "fooA" },
       new QuestionB { Id = 1, OptionB = 1, Text = "fooB" }
    };
    List<QuestionModel> model = new List<QuestionModel>();
    questions.ForEach(q => model.Add(q.GetType().Equals(typeof(QuestionA)) ?
                (QuestionModel)(new QuestionAModel((QuestionA)q)) : new QuestionBModel((QuestionB)q)));
