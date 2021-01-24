    public class QuestionAndAnswers
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public int IndexOfCorrectAnswer { get; set; }
        public static QuestionAndAnswers Parse(string qaInput)
        {
            if (qaInput == null) throw new ArgumentNullException(nameof(qaInput));
            var result = new QuestionAndAnswers();
            var parts = Regex.Split(qaInput, @"\|?\s+(?=[A-Z]\.)");
            result.Question = parts[0].TrimEnd('.');
            result.Answers = parts.Skip(1).ToList();
            return result;
        }
        public override string ToString()
        {
            return $"{Question}\n  {string.Join("\n  ", Answers)}";
        }
    }
