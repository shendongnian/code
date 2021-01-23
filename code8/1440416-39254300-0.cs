    List<QuestionAndAnswer> qList = new List<QuestionAndAnswer();
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, please enter how many questions you would like to have on this reapeting test");
        int numberofquestions = Convert.ToInt32(Console.ReadLine());
       for(int i=0;i<numberofquestions;i++){        {
            Console.WriteLine(" what do you want question number " + numberofquestions + " to be?");
            QuestionAndAnswer question = new QuestionAndAnswer(null,null);
            question.answer = Console.ReadLine();
            Console.WriteLine(" what do you want question number " + i.ToString() + "'s answer to be?");
            question.answer = Console.ReadLine();
            qList.Add(question);
            //NumberOfQuestions is now qList.Count
        }
        }
    }
