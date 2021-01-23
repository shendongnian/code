    private bool playAgain()
    {
        int number = 2; //Invalid option: close game
        Int32.TryParse(Console.ReadLine(), out number);
        if (number == 1)
        {
            return true;
        }
        else if (number == 2)
        {
            return false;
        }
        else
        {
            Console.WriteLine("Unknown option, quitting!");
            return false;
        }
    }
