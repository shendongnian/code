    public class Score
    {
        public Score(DateTime date, int score, int questionsAsked)
        {
            Date = date;
            Score = score;
            QuestionsAsked = questionsAsked;
        }
        public DateTime Date { get; }
        public int Score { get; }
        public int QuestionsAsked { get; }
    }
