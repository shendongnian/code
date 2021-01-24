    loopContinue = true;
    while (loopContinue)
    {
        Console.WriteLine("Which book would you like to check out?");
        Console.WriteLine("select 1 for book 1, 2 for book 2, and 3 for book 3");
        // Use TryParse when reading the user input. This will avoid an 
        // Exception if the user types a letter for example.
        if(Int32.TryParse(Console.ReadLine(), int out choice)
        {
            switch (choice)
            {
                case 1:
                   ....
                   loopContinue = false;
                   break;
                case 2:
                   ....
                   loopContinue = false;
                   break;
                case 3:
                   ....
                   loopContinue = false;
                   break;
                // not really needed, if you remove the default
                // then your loop will not exit and you can start again
                default:
                   loopContinue = true;
                   break;
        }
        if(loopContinue)
             Console.WriteLine("Please enter a valid choice.");
    }
