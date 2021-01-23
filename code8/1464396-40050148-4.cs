    var sections = db.getSections.ToList();
    var questions = db.getQuestions.GroupBy(item => item.SectionID)
                                   .ToDictionary(key => key.Key,
                                                 value => value.Select(i => i).ToList());
    foreach (var section in sections)
    {
        List<Question> selectedQuestions;
        if (efficientQuestions.TryGetValue(section.SectionID, out selectedQuestions))
        {
            section.Questions = selectedQuestions;
        }
    }
