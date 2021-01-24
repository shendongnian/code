    do
    {
        Console.Write("Please enter something ");
        userInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(userInput))
        {
            collection.Add(userInput);
        }
    }while(string.IsNullOrEmpty(userInput));
