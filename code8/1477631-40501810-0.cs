    public class QuestionVM
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public int? AnswerID { get; set; }
        [Range(0, 5)]
        public int? Response { get; set; }
    }
