    string First;
    int score = 0;
    int attempts = 2; //our integer variable 
    string Second;
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    while (attempts > 0)
    {
        //First question
        Console.WriteLine("Where is  the capital of the state of Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa"); //use WriteLine instead of Write, for console clarity
        First = Console.ReadLine();
        switch (First.ToUpper()) //accept lowercase inputs
        {
            case "B": Console.WriteLine("You entered the correct answer!"); break;
            case "A": case "C": case "D": Console.WriteLine("You entered the wrong answer."); break; //same logic
            default: Console.WriteLine("You did not enter a correct answer."); break;
        }
        if (First.ToUpper() == "B")
        {
            score = score + 50;
            Console.WriteLine("Correct!\n" + " score:" + score + "\n");
            break; //force exit loop, onto the next question
        }
        else
        {
            Console.WriteLine("Wrong!\n" + " score:" + score + "\n");
            attempts--; //decrease number of attempts left
        }
     }
     while(attempts > 0)
     {
        //Second question
        Console.WriteLine("Where is Walt Disney World Park located in Florida? A.Orlando,B.Tallahassee, C. Miami, or D. Tampa");
        Second = Console.ReadLine();
        switch (Second.ToUpper()) //accept lowercase inputs
        {
            case "A": Console.Write("You entered the correct answer!"); break;
            case "B": case "C": case "D": Console.WriteLine("You entered the wrong answer."); break;
            default: Console.WriteLine("You did not enter a correct answer."); break;
        }
        if (Second.ToUpper() == "A")
        {
            score = score + 50;
            Console.WriteLine("Correct!\n" + " score:" + score + "\n");
            break; //you win!
        }
        else
        {
            Console.WriteLine("Wrong!\n" + " score:" + score + "\n");
            attempts--; //decrease number of attempts left
        }
    }
