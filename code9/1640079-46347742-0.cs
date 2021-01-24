    public static List<SurveyResponse> GetSurveyResponse(int responseId)
    {
        using (CaseDatabaseEntities entities = BaseDAL.GetNewEntities())
        {
            SURVEY_RESPONSES sr = entities.SURVEY_RESPONSES
                                                    .Where(r => r.ResponseId == responseId).FirstOrDefault();
            var Answers = entities.SURVEY_ANSWERS.Where(a => a.ResponseId == responseId).;
            var Questions = entities.SURVEY_QUESTIONS.Where(q => q.SurveyId == sr.SurveyId);
            var questionsWithAnswers = (from q in Questions
                        join a in Answers on q.QuestionId equals a.QuestionId
                        select new SurveyResponse(){ ResponseId = a.responseId, Question = q.Question, Answer = a.Answer}).ToList()
            return questionsWithAnswers;
        }
    }
