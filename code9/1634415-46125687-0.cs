        public static void Main()
    {
        Survey survey = new Survey("Survey");
        Question tq1 = new TextQuestion();
		Question tq2 = new TextQuestion();
        tq1.Ask();
		tq2.Ask();
		survey.AddQuestion(tq1);
		survey.AddQuestion(tq2);
		
		int score = survey.GetScore();
		Console.WriteLine("Your score: {0}", score);
    }
}
