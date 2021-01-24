    public static string MorseEncode(string inputString)
    {
        var codeBuilder = new StringBuilder();
        foreach (char input in inputString)
        {
            // Assuming you have a method to get a morse char from a normal char
            char encodedChar = GetMorseChar(input);  
            // Append our encoded char to our StringBuilder
            codeBuilder.Append(encodedChar);
        }
        // Return the String representation of our StringBuilder
        return codeBuilder.ToString()
    }
