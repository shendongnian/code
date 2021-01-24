     public class Question
    {
        public int QuestionID { get; set; }
        public string Title { get; set; }
        public bool Selected { get; set; }
    }
    public class EventCompanyQuestionnaireQuestions
    {
        public int EventID { get; set; }
        public int CompanyID { get; set; }
        public List<Question> Questions { get; set; }
    }
