    private static double GetDoubleFromUser(string prompt = null, string errorPrompt = null, 
        double minValue = double.MinValue, double maxValue = double.MaxValue)
    {
        double value;
        // Write the prompt text and get input from user
        if (prompt != null) Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out value)
                || value < minValue || value > maxValue)
        {
            // If input can't be converted to a double or is out of range, keep trying
            if (errorPrompt != null) Console.Write(errorPrompt);
        }
        // Return converted input value
        return value;
    }
