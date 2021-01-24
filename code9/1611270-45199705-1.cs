    /// <summary>
    /// Gets a line of text from the user, restricted to specific characters.
    /// </summary>
    /// <param name="validInput">Characters that the user is allowed to enter.</param>
    /// <param name="prompt">An optional prompt to display to the user.</param>
    /// <param name="allowEmpty">If true, allows empty string input.</param>
    /// <returns>The line of text entered by the user.</returns>
    private static string ReadLineRestricted(List<char> validInput = null, 
        string prompt = null, bool allowEmpty = true)
    {
        // Show prompt
        if (prompt != null) Console.Write(prompt);
        // Ensure we capture end-of-line characters
        if (validInput == null) validInput = new List<char>();
        if (!validInput.Contains('\n')) validInput.Add('\n');
        if (!validInput.Contains('\r')) validInput.Add('\r');
        // Capture valid characters until the end of the line
        string output = string.Empty;
        while(true)
        {
            var input = ReadCharRestricted(validInput);
            if (input == '\n' || input == '\r')
            {
                if (!string.IsNullOrWhiteSpace(output) || allowEmpty) break;
                Console.CursorLeft = prompt?.Length ?? 0;                    
            }
            else
            {
                output += input;
            }
        }
        Console.WriteLine();
        return output;
    }
