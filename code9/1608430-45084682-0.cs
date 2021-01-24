    bool loop = true;
    
    while(loop)
    {
        Console.WriteLine("Question");
        Console.WriteLine("1. Ans1");
        Console.WriteLine("2. Ans2");
        Console.WriteLine("3. Exit");
        string resp = Console.ReadLine();
        
        switch(resp)
        {
            case "1":
            Console.WriteLine("Ans1 chosen");
            break;
            case "2":
            break;
            case "3":
            loop = false;
            break;
            default:
            Console.WriteLine("Invalid Input. Please try Again");
            break;        
        }
    }
