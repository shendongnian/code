    public static string MorseEncode(string inputString)
    {
        if (inputString == null) return null;
        var codeBuilder = new StringBuilder();
        foreach (char input in inputString)
        {
            // Assuming you have a method to get the morse code for a char
            string encodedChar = GetMorseCode(input);  
            // Append our encoded char to our StringBuilder
            codeBuilder.Append(encodedChar);
        }
        // Return the String representation of our StringBuilder
        return codeBuilder.ToString();
    }
