    public class Choice
    {
         public Choice (string choiceText, string answer)
         {
             ChoiceText = choiceText;
             Answer = answer;
         }
         public string ChoiceText { get; }
         public string Answer { get; }
    }
    public class Question
    {
        public Question (string questionText)
        {
            QuestionText = questionText;
        }
        public string QuestionText { get; }
        public List<Choice> Choices { get; } = new List<Choice>();
    }
