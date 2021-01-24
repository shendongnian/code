    /// <summary>
    /// Prompts the user for input, and returns the first valid character they type.
    /// </summary>
    /// <param name="validInput">A list of valid characters. 
    /// All characters will be accepted if this is null or empty.</param>
    /// <param name="prompt">An optional prompt to display to the user.</param>
    /// <returns>The first valid character entered by the user.</returns>
    private static char ReadCharRestricted(ICollection<char> validInput = null, 
        string prompt = null)
    {
        // Show prompt
        if (prompt != null) Console.Write(prompt);
        var cursorLeft = Console.CursorLeft;
        var input = Console.ReadKey().KeyChar;
        // Get input character, ignoring any that don't exist in 'validInput'
        while (validInput != null && validInput.Any() && !validInput.Contains(input))
        {
            Console.CursorLeft = cursorLeft;
            Console.Write(' ');
            Console.CursorLeft--;
            input = Console.ReadKey().KeyChar;
        }
        return input;
    }
