    var questionList = new List<QandA>();
    ///...
    public class QandA
    {
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        internal int CorrectIndex { get; set; }
    }
