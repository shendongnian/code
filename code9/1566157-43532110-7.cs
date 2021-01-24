    private static int GetIntFromUser(string prompt)
    {
        int value;
        // Write the prompt text and get input from user
        Console.Write(prompt);
        string input = Console.ReadLine();
        // If input can't be converted to a double, keep trying
        while (!int.TryParse(input, out value))
        {
            Console.Write($"'{input}' is not a valid number. Please try again: ");
            input = Console.ReadLine();
        }
        // Input was successfully converted!
        return value;
    }
