    static void Main(string[] args)
        {
            List<Account> accountsList = new List<Account>();
            accountsList.Add(new Account { UserName = "jack", Password = "111", Group = 1 });
            accountsList.Add(new Account { UserName = "ibo", Password = "121", Group = 2 });
            Console.Write("enter username >> ");
            string username = Console.ReadLine();
            Console.Write("enter password >> ");
            string password = Console.ReadLine();
            if (CheckUserPassword(accountsList, username, password))
            {
                List<Question> questions = FillQuestions();
                int result = 0;
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].DesiredGroup == accountsList.Find(x => x.UserName == username).Group)
                    {
                        continue;
                    }
                    Console.WriteLine();
                    Console.WriteLine(questions[i].QuestionText);
                    Console.WriteLine("--------------------------");
                    WriteAnswers(questions[i].AnswersList);
                    string answers = Console.ReadLine();
                    for (int j = 0; j < questions[i].AnswersList.Count; j++)
                    {
                        if (questions[i].AnswersList[j].AcceptableLetter == answers)
                        {
                            if (questions[i].AnswersList[j].IsCorrect)
                            {
                                Console.WriteLine(questions[i].AnswersList[j].AcceptableLetter + " is correct");
                                result += 10;
                            }
                            else
                            {
                                Console.WriteLine(questions[i].AnswersList[j].AcceptableLetter + " is incorrect");
                            }
                        }
                    }
                }
                if (result < 15)
                {
                    Console.WriteLine("failed");
                }
                else
                {
                    Console.WriteLine("congrats");
                }
            }
            Console.Read();
        }
        private static void WriteAnswers(List<Answer> answersList)
        {
            char[] alphabetLetters = { 'a', 'b', 'c' };
            for (int i = 0; i < answersList.Count; i++)
            {
                Console.WriteLine(alphabetLetters[i] + ") " + answersList[i].AnswerText);
            }
        }
        private static List<Question> FillQuestions()
        {
            List<Question> questionList = new List<Question>();
            List<Answer> answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "Ankara", IsCorrect = true, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "Istambul", IsCorrect = false, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "Izmir", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "Türkiyenin baskenti neresidir?", AnswersList = answerList, DesiredGroup = 1 });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "ismet", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "Atatürk", IsCorrect = true, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "Ali", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "Baskomutan kim?", AnswersList = answerList, DesiredGroup = 1 });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "1", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "2", IsCorrect = false, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "4", IsCorrect = true, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "2 kere 2?", AnswersList = answerList, DesiredGroup = 2 });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "1912", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "1914", IsCorrect = true, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "1915", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "When did the world war 1 start?", AnswersList = answerList, DesiredGroup = 2 });
            return questionList;
        }
        private static bool CheckUserPassword(List<Account> accountsList, string username, string password)
        {
            foreach (Account account in accountsList)
            {
                if (account.UserName == username)
                {
                    if (account.Password == password)
                    {
                        Console.WriteLine("welcome " + account.UserName);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("invalid access");
                        return false;
                    }
                }
            }
            return false;
        }
        class Account
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public int Group { get; set; }
        }
        class Question
        {
            public string QuestionText { get; set; }
            public List<Answer> AnswersList { get; set; }
            public int DesiredGroup { get; set; }
        }
        class Answer
        {
            public string AnswerText { get; set; }
            public bool IsCorrect { get; set; }
            public string AcceptableLetter { get; set; }
        }
