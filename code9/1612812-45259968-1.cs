    class QuizItem
    {
        public string Question;
        public int IndexOfCorrectAnswer;
        public List<string> PossibleAnswers;
        private bool isMultipleChoice => PossibleAnswers.Count() > 1;
        public QuizItem(string question, List<string> possibleAnswers, 
            int indexOfCorrectAnswer)
        {
            // Argument validation
            if (string.IsNullOrWhiteSpace(question))
                throw new ArgumentException(
                    "The question cannot be null or whitespace.", 
                    nameof(question));
            if (possibleAnswers == null || !possibleAnswers.Any())
                throw new ArgumentException(
                    "The list of possible answers must contain at least one answer.",
                    nameof(possibleAnswers));
            if (indexOfCorrectAnswer < 0 || indexOfCorrectAnswer >= possibleAnswers.Count)
                throw new ArgumentException(
                    "The index specified must exist in the list of possible answers.",
                    nameof(indexOfCorrectAnswer));
            Question = question;
            PossibleAnswers = possibleAnswers;
            IndexOfCorrectAnswer = indexOfCorrectAnswer;
        }
        public bool AskQuestion()
        {
            var correct = false;
            Console.WriteLine(Question);
            if (isMultipleChoice)
            {
                for (int i = 0; i < PossibleAnswers.Count; i++)
                {
                    Console.WriteLine($"  {i + 1}: {PossibleAnswers[i]}");
                }
                int response;
                do
                {
                    Console.Write($"\nEnter answer (1 - {PossibleAnswers.Count}): ");
                } while (!int.TryParse(Console.ReadLine().Trim('.', ' '), out response) ||
                         response < 1 ||
                         response > PossibleAnswers.Count);
                correct = response - 1  == IndexOfCorrectAnswer;
            }
            else
            {
                Console.WriteLine("\nEnter your answer below:");
                var response = Console.ReadLine();
                correct = IsCorrect(response);
            }
            
            Console.ForegroundColor = correct ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(correct ? "Correct" : "Incorrect");
            Console.ResetColor();
            return correct;
        }
        public bool IsCorrect(string answer)
        {
            return answer != null &&
                answer.Equals(PossibleAnswers[IndexOfCorrectAnswer],
                StringComparison.OrdinalIgnoreCase);
        }
    }
