    while (true)
    {
        Console.Write("What equals " + rndNumber1 + " + " + rndNumber2 + ": ");
        string input = Console.ReadLine();
        int answer = int.Parse(input);
        if (answer == rndNumber1 + rndNumber2)
        {
            Console.WriteLine("Your answer is correct.");
            break;
        }
        else
        {
            Console.WriteLine("Your answer is incorrect. Try again.");
        }
    }
