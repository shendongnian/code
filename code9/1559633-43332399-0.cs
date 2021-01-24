    public class Question
    {
        public long? Id { get; set; }
        public string Title { get; set; }
        public QuestionFamily? Family { get; set; }
        public List<Headings> Headings { get; set; }
        public string Heading { get; set; } 
        public bool? Visible { get; set; }
        public bool? ForcedRanking { get; set; }
        internal string Href { get; set; }
        public QuestionAnswers Answers { get; set; }
        public string Nickname { get; set; }
        public Question()
        {
            Answers = new QuestionAnswers();
        }
    }
    public class QuestionAnswers
    {
        public List<Choice> Choices { get; set; }
        public OtherAnswer Other { get; set; }
        public QuestionAnswers()
        {
            Choices = new List<Choice>();
        }
    }
 
    flatData = (from s in surveyDetails
                        from p in s.Pages
                        from q in p.Questions
                        from h in q.Headings.DefaultIfEmpty()
                        from c in q.Answers.Choices.DefaultIfEmpty(new Choice())
                        select new SurveyQuestionOption
                        {
                            SurveyID = s.Id == null ? null : s.Id,
                            SurveyTitle = s.Title == null ? null : s.Title,
                            DateCreated = s.Date_Created == null ? null : s.Date_Created,
                            DateModified = s.Date_Modified == null ? null : s.Date_Modified,
                            QuestionID = q.Id == null ? null : q.Id,
                            QuestionTitle = q.Title == null ? null : q.Title,
                            QuestionType = q.Family.Value.ToString(),
                            QuestionText = h.Heading.FirstOrDefault().ToString() == null ? null : h.Heading.FirstOrDefault().ToString(),
                            AnswerOptionID = c.Id == null ? null : c.Id,
                            AnswerOptionText = c.Text == null ? null : c.Text
                        }).ToList<SurveyQuestionOption>();
