    List<QuestionAndAnswer> qList = new List<QuestionAndAnswer>();
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, please enter how many questions you would like to have on this reapeting test");
        int numberofquestions = Convert.ToInt32(Console.ReadLine());
       for(int i=0;i<numberofquestions;i++){        
            Console.WriteLine(" what do you want question number " + i.ToString() + "'s QUESTION to be?");
            QuestionAndAnswer question = new QuestionAndAnswer(null,null);
            question.question = Console.ReadLine();
            Console.WriteLine(" what do you want question number " + i.ToString() + "'s ANSWER to be?");
            question.answer = Console.ReadLine();
            qList.Add(question);
            //NumberOfQuestions is now qList.Count
        }
        
        startFlash();
    }
    private static void startFlash(){
        string hell = "hot";
        Random rnd = new Random();
        while(hell!="freezing"){
        
        int index = rnd.Next(qList.Count);
        QuestionAnswer qA = qList[index];
        Console.WriteLine("Question "+index.ToString()+": "+qA.question);
        Console.ReadKey(true);
        Console.WriteLine(Answer: "+qA.answer);
        }
    } 
