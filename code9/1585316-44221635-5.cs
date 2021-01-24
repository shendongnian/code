        private static List<Question> FillQuestions()
        {
            List<Question> questionList = new List<Question>();
            List<Answer> answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "Ankara", IsCorrect = true, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "Istambul", IsCorrect = false, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "Izmir", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "Türkiyenin baskenti neresidir?", AnswersList = answerList });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "ismet", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "Atatürk", IsCorrect = true, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "Ali", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "Baskomutan kim?", AnswersList = answerList });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "1", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "2", IsCorrect = false, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "4", IsCorrect = true, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "2 kere 2?", AnswersList = answerList });
            answerList = new List<Answer>();
            answerList.Add(new Answer { AnswerText = "1912", IsCorrect = false, AcceptableLetter = "a" });
            answerList.Add(new Answer { AnswerText = "1914", IsCorrect = true, AcceptableLetter = "b" });
            answerList.Add(new Answer { AnswerText = "1915", IsCorrect = false, AcceptableLetter = "c" });
            questionList.Add(new Question { QuestionText = "When did the world war 1 start?", AnswersList = answerList });
            return questionList;
        }
