    var maxAnswerCount = dc.Connaissance.GroupBy(answer => answer.ID_Question)
                                        .Select(answerGroup => answerGroup.Count())
                                        .Max();
    
    var questions = (from question in dc.Questions
                     join answer in dc.Connaissance on question.ID_Q equals answer.ID_Question
                     group answer by answer.ID_Question into answerGroup
                     where answerGroup.Count() == maxAnswerCount
                     select question.Libelle).Distinct()
