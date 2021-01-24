    string userInput;
    bool again;
    do
    {
        Console.Write("Please enter something ");
        userInput = Console.ReadLine();
        if (again = !string.IsNullOrEmpty(userInput))
            collection.Add(userInput);
    } while (again);
