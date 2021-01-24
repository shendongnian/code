    public static string GetStringFromUser(string prompt, int minLength,
        bool allowAlpha, bool allowNumeric, bool allowNonAlphaNumeric)
    {
        var errorMessage = new StringBuilder();
        var input = string.Empty;
        while (true)
        {
            errorMessage.Clear();
            Console.Write(prompt);
            input = Console.ReadLine();
            if (input.Length < minLength)
            {
                errorMessage.AppendLine(
                    $" - Entry must be longer than {minLength} characters");
            }
            if (!allowAlpha && input.Any(c => char.IsLetter(c)))
            {
                errorMessage.AppendLine(" - Entry must not contain any letters");
            }
            if (!allowNumeric && input.Any(c => char.IsDigit(c)))
            {
                errorMessage.AppendLine(" - Entry must not contain any numbers");
            }
            if (!allowNonAlphaNumeric && input.Any(c => !char.IsLetterOrDigit(c)))
            {
                errorMessage.AppendLine(
                    " - Entry must not contain any non-alphanumeric characters");
            }
            if (errorMessage.Length == 0) break;
            Console.WriteLine("\nThe following errors must be corrected:");
            Console.WriteLine(errorMessage.ToString());
        }
        Console.WriteLine();
        return input;
    }
