    public class QuestionRoot
    {
        public Question Question { get; set; }
    }
    
    public class Question
    {
        public string questionType { get; set; }
        public string categoryID { get; set; }
        public string bonusBool { get; set; }
        public string answerText { get; set; }
        public string questionText { get; set; }
        public string ID { get; set; }
    }
