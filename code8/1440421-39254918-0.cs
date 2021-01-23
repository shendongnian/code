    class Program
    {
        
        static void Main(string[] args)
        {
            //Use a list to collect your QuestionAndAnswer objects
            List<QuestionAndAnswer> questions = new List<QuestionAndAnswer>();
            Console.WriteLine("Hello, please enter how many questions you would like to have on this reapeting test");
            int questionCount = 1;
          
            // loops until you type finished
            while (true)
            {
                Console.WriteLine(" what do you want question number " + questionCount + " to be?");
                QuestionAndAnswer question = new QuestionAndAnswer(null, null);
                string response = Console.ReadLine();
                if (response.ToUpper() == "FINISHED") break;
                question.question = response;
                Console.WriteLine(" what do you want question number " + questionCount + "'s answer to be?");
                question.answer = Console.ReadLine();
                //Add the question (QuestionAndAnswer) to the list
                questions.Add(question);
                question.questionNumber = questionCount;
                questionCount++;
            }
            //This section will ask the questions until you type exit
            while (true)
            {
                foreach (QuestionAndAnswer qa in questions)
                {
                    Console.WriteLine(String.Format("Question #{0} out of {1}: {2}", qa.questionNumber, questions.Count(), qa.question));
                    Console.Write("Type you answer and hit <Enter>: ");
                    if(Console.ReadLine().ToUpper()=="EXIT") break;
                    Console.WriteLine(qa.answer);
                }
            }
        }
    }
    class QuestionAndAnswer
    {
        public string question;
        public string answer;
        public int questionNumber;
        public QuestionAndAnswer(string _question, string _answer)
        {
            question = _question;
            answer = _answer;
        }
    }
