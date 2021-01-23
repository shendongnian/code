    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Quiz_StackOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                var quizGenerator = new QuizGenerator();
                var quiz = quizGenerator.GenerateQuiz();
                var quizProctor = new QuizProctor();
                var grade = quizProctor.ProctorQuiz(quiz);
                Console.WriteLine(grade.ToString());
                Console.WriteLine("Done. Press any key to exit.");
                Console.ReadKey();
            }
        }
        public class QuizGenerator
        {
            public Quiz GenerateQuiz()
            {
                var problems = GenerateProblems();
                var quiz = new Quiz()
                {
                    Problems = problems
                };
                return quiz;
            }
            private List<Problem> GenerateProblems()
            {
                List<Problem> problems = new List<Problem>();
                int numChoices = InputValidator.GetPositiveNumber("Enter number of problems:  ");
                for (int i = 0; i < numChoices; i++)
                {
                    Problem problem = GenerateProblem();
                    problems.Add(problem);
                }
                return problems;
            }
            private Problem GenerateProblem()
            {
                var question = GenerateQuestion();
                var choices = GenerateChoices();
                var answer = GenerateAnswer(choices);
                var problem = new Problem()
                {
                    Question = question,
                    Choices = choices,
                    Answer = answer
                };
                return problem;
            }
            private string GenerateQuestion()
            {
                Console.WriteLine("Enter the question: ");
                string question = Console.ReadLine();
                return question;
            }
            private List<string> GenerateChoices()
            {
                List<string> choices = new List<string>();
                int numChoices = InputValidator.GetPositiveNumber("Enter number of choices for the question:  ");
                for (int i=1; i<=numChoices; i++)
                {
                    string choice = GenerateChoice(i);
                    choices.Add(choice);
                }
                return choices;
            }
            private string GenerateChoice(int index)
            {
                Console.WriteLine($"Enter Choice {index} for the question: ");
                string choice = Console.ReadLine();
                return choice;
            }
            private Answer GenerateAnswer(List<string> choices)
            {
                Console.WriteLine("Enter the answer: ");
                string userChoice = InputValidator.GetUserChoice(new Problem() { Choices=choices });
                var answer = new Answer()
                {
                    Value = userChoice
                };
                return answer;
            }
        }
        public class QuizProctor
        {
            public Grade ProctorQuiz(Quiz quiz)
            {
                var answers = new List<Answer>();
                foreach(Problem problem in quiz.Problems)
                {
                    Answer answer = ProctorProblem(problem);
                    answers.Add(answer);
                }
                Grade grade = quiz.Grade(answers);
                return grade;
            }
            private Answer ProctorProblem(Problem problem)
            {
                string userChoice = InputValidator.GetUserChoice(problem);
                var answer = new Answer()
                {
                    Value = userChoice
                };
                return answer;
            }
        }
        public class Quiz
        {
            public List<Problem> Problems { get; set; }
            public Grade Grade(List<Answer> answers)
            {
                List<Answer> answerKey = Problems.Select(x => x.Answer).ToList();
                var rawResults = new List<Tuple<Answer, Answer>>();
                for(int i=0; i<answers.Count; i++)
                {
                    Answer correct = answerKey[i];
                    Answer provided = answers[i];
                    rawResults.Add(new Tuple<Answer, Answer>(correct, provided));
                }
                return new Grade(rawResults);
            }
        }
        public class Grade
        {
            private List<Tuple<Answer, Answer>> RawResults { get; set; }
            public decimal Percent
            {
                get { return decimal.Divide(RawResults.Count(x => x.Item1.Equals(x.Item2)), RawResults.Count); }
            }
            public Grade(List<Tuple<Answer, Answer>> rawResults)
            {
                RawResults = rawResults;
            }
            public override string ToString()
            {
                return string.Format("You scored a {0:P2}.", Percent);
            }
        }
        public class Problem
        {
            public string Question { get; set; }
            public List<string> Choices { get; set; }
            public Answer Answer { get; set; }
            public string Prompt()
            {
                Func<int, char> numberToLetter = (int n) =>
                {
                    return (char)('A' - 1 + n);
                };
                string prompt = Question;
                for (int i=0; i<Choices.Count; i++)
                {
                    string choice = Choices[i];
                    prompt += $"\n{numberToLetter(i+1)}) {choice}";
                }
                return prompt;
            }
        }
        public class Answer
        {
            public string Value { get; set; }
            public override string ToString()
            {
                return Value + "";
            }
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                return (obj as Answer).Value.Equals(Value);
            }
            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }
        }
        public static class InputValidator
        {
            public static int GetPositiveNumber(string prompt)
            {
                int number = -1;
                while (number < 0)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    try
                    {
                        number = int.Parse(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Please input a positive number.");
                    }
                }
                return number;
            }
            public static string GetUserChoice(Problem problem)
            {
                Func<char, int> letterToNumber = (char c) =>
                {
                    if (char.IsLower(c))
                    {
                        return (int)(c - 'a' + 1);
                    }
                    return (int)(c - 'A' + 1);
                };
                char userChoiceLetter = '_';
                while (!char.IsLetter(userChoiceLetter))
                {
                    Console.WriteLine(problem.Prompt());
                    Console.Write("Answer:  ");
                    var input = Console.ReadLine();
                    try
                    {
                        userChoiceLetter = char.Parse(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Please input a letter corresponding to your choice.");
                    }
                }
                int answerIndex = letterToNumber(userChoiceLetter) - 1;
                return problem.Choices[answerIndex];
            }
        }
    }
