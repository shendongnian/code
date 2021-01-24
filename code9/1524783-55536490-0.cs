    var questionnaire= _context.Questionnaire.FirstOrDefault(qn => qn.Id == questionnaireId);
    questionnaire.Answers = _context.Entry(questionnaire)
     .Collection(b => b.Answers )
     .Query()
     .Where(a => a.UserId == userId).ToList();
