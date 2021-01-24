    class Question
    {
        public string Text { get; private set; }
        public string Answer { get; private set; }
        public Question(string text, string answer)
        {
            Text = text;
            Answer = answer;
        }
    }
