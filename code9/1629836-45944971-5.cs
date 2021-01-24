    public class QuestionTxt
    {
        public List<Answer> answers { get; set; }  // notice public!
        public string name { get; set; }
        public QuestionTxt()
        {
            answers = new List<Answer>();
        }
    }
