    ex.ExamResults
       .GroupBy(p => new
                {
                    p.Question.Chapter.ChapterName,
                    p.AnswerPower
                })
        .Where(p => p.AnswerPower!=1)
        .Select(g => new
                {
                    g.Key.ChapterName,
                    Mistakes = g.Count()
                });
