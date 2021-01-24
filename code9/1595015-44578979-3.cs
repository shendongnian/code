    bool validInput = true;
    while (validInput == true)
    {
        string input = Console.ReadLine();
        int x;
        if (int.TryParse(input, out x))
        {
            Console.WriteLine(x);  // output the integer
        }
        else
        {
            Console.WriteLine("Input was not an integer");
            validInput = false;
        }
    }
    
