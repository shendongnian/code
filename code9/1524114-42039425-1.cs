    char ChooseAction(string message)
    {
        Console.WriteLine(message);
        string input = string.Empty;
        while ( (input = Console.ReadLine()) != "exit") 
        {
            char c = input.Trim()[0];
            if ( c >= 0x31 && c <= 0x37)
                return c;
            Console.WriteLine("Wrong input. Try again...");
        } 
        return 0x38;       
    }
