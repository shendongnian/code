    public class Question
    {
        public int QuestionId {get; set;}
        public string QuestionText {get; set;}
        public List<Answer> Answers {get; set;
    }
    public class Answer
    {
        public int AnswerId {get; set;}
        public int QuestionId {get; set;}
        public string AnswerText {get;set;}
    }
