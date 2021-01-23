    public bool IsUserWillingToContinue()
    {
        int choice2;
        string input;
        Console.WriteLine("");
        Console.WriteLine("Type 1 to play again, type 2 to close the application");
        input = Console.ReadLine();
        int.TryParse(input, out choice2);
 
        return choice2 == 1;
    }
