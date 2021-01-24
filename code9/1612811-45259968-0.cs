    class StaffTest
    {
        public List<QuizItem> QuizItems = new List<QuizItem>();
        public int Score { get; private set; }
        public double ScorePercent => (double)Score / QuizItems.Count * 100;
        public string Grade =>
            ScorePercent < 60 ? "F" :
            ScorePercent < 70 ? "D" :
            ScorePercent < 80 ? "C" :
            ScorePercent < 90 ? "B" : "A";
        public double ElapsedSeconds => stopwatch.Elapsed.TotalSeconds;
        
        private Stopwatch stopwatch = new Stopwatch();
        public void BeginTest()
        {
            stopwatch.Restart();
            for (int i = 0; i < QuizItems.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Question #{i + 1}: ");
                Console.ResetColor();
                if (QuizItems[i].AskQuestion()) Score++;
                Console.WriteLine();
            }
            stopwatch.Stop();
        }
    }
