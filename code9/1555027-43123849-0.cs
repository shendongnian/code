    /// <summary>
    /// Gets a strongly typed (double) value from the Console
    /// </summary>
    /// <param name="prompt">The initial message to display to the user</param>
    /// <returns>User input converted to a double</returns>
    private static double GetDoubleFromUser(string prompt)
    {
        double value;
        // Write the prompt text and get input from user
        Console.Write(prompt);
        string input = Console.ReadLine();
        // If input can't be converted to a double, keep trying
        while (!double.TryParse(input, out value))
        {
            Console.Write($"'{input}' is not a valid number. Please try again: ");
            input = Console.ReadLine();
        }
        // Input was successfully converted!
        return value;
    }
