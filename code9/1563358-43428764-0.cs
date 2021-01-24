    bool TryGetUserInput(out string userInput) {
        Console.Write("Please enter something ");
        userInput = Console.ReadLine();
        return !string.IsNullOrEmpty(userInput);
    }
    ...
    string userInput;
    while (TryGetUserInput(out userInput))
        collection.Add(userInput);
