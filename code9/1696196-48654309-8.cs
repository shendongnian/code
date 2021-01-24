    public static bool GetBoolFromUser(string prompt, List<string> validTrueResponses, 
        List<string> validFalseResponses, StringComparison comparisonType)
    {
        string response;
        // Combine all valid responses for the sake of the loop
        var allValidResponses = 
            validTrueResponses?.Union(validFalseResponses) ?? validFalseResponses;
        do
        {
            Console.Write(prompt);
            response = Console.ReadLine();
        } while (allValidResponses != null &&
                 !allValidResponses.Any(r => r.Equals(response, comparisonType)));
        // Now return true or false depending on which list the response was found in
        return validTrueResponses?.Any(r => r.Equals(response, comparisonType)) ?? false;
    }
