    public class Question
    {
        public int Id { get; set; }
        public string Question { get; set; }
        //relations
        public List<Answer> Answers { get; set; }
    }
    public class Answer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool Correct { get; set; }
        public int QuestionId { get; set; }
        //relations
        public Question Question { get; set; }
    }
