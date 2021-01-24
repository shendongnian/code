    static void Main(string[] args)
    {
        ...
        Console.WriteLine("Please enter a number");
        string numberString = Console.ReadLine();
        int number = ConvertAndValidateNumber(number); // we are now going to return an int
        ...
    }
