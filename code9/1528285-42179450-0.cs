    public class Quiz
        {
            private static Random rnd = new Random();
            public Question[] Questions = new[]
            {
                new Question
                {
                    QuestionText = "Sample uestion 1?",
                    CorrectAnswer = "Answer to question 1",
                    WrongAnswers = new [] {
                        "Wrong answer 1",
                        "Wrong answer 2",
                        "Wrong answer 3",
                        "Wrong answer 4",
                        "Wrong answer 5",
                    }
                },
                new Question
                {
                    QuestionText = "Sample uestion 2?",
                    CorrectAnswer = "Answer to question 2",
                    WrongAnswers = new [] {
                        "Wrong answer 1",
                        "Wrong answer 2",
                        "Wrong answer 3",
                        "Wrong answer 4",
                        "Wrong answer 5",
                    }
                }
            };
            public class Question
            {
                public string QuestionText { get; set; }
                public string CorrectAnswer { get; set; }
                public string[] WrongAnswers { get; set; }
                public string[] GetMultipleChoice(int numberOfChoices)
                {
                    var list = new List<string>() { CorrectAnswer };
                    list.AddRange(WrongAnswers.Take(numberOfChoices - 1));
                    // shuffle
                    int n = list.Count;
                    while (n > 1)
                    {
                        n--;
                        int k = rnd.Next(n + 1);
                        var value = list[k];
                        list[k] = list[n];
                        list[n] = value;
                    }
                    return list.ToArray();
                }
            }
        }
