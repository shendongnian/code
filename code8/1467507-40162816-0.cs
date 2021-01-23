    public class Question {
        public string Text { get; set;}
        public IList<Answer> Answers { get; set;}
    }
    
    public class Answer {
        public string Label { get; set;}
        public string Text { get; set;}
        public bool IsCorrect { get; set;}
    }
