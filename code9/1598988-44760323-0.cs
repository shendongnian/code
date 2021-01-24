    string userInput;
    double parsedValue;
    bool valueIsGood;
    do
    {
        Console.Write("Enter the first value: ");
        userInput = Console.ReadLine();
        userInput = userInput?.Trim(); // get rid of leading and trailing spaces
        valueIsGood = 
            string.IsNullOrEmpty(userInput) == false
            && double.TryParse(userInput, out parsedValue);
        if (!valueIsGood)
        {
            Console.WriteLine("You must enter a number.");
        }
    while (!valueIsGood);
