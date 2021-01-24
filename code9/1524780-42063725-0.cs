    questionnaire = _context.Questionnaires
        .Select(n => new Questionnaire
        {
            Id = n.Id,
            Name = n.Name.
            Questions = n.Questions.Select(q => new Question
            {
               Id = q.Id,
               Text = q.Text,
               Answers = q.Where(a => a.UserId == userId)
            }
        }
        .FirstOrDefault(qn => qn.Id == questionnaireId);
