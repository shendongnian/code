      var query = ex.ExamResults
            .GroupBy(p => new
        {
            p.Question.Chapter.ChapterName
        })
        .Select(g => new
        {
            g.Key.ChapterName,
            Mistakes = g.Count(x => x.AnswerPower!=1),
            CorrectAnswers = g.Count(x => x.AnswerPower==1)
        });
