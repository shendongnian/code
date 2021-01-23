    List<string> strings = new List<string>() { "102.123.444,696", "102,123,444.666",
                "444.666", "123,444.666", "0.666", ".666", "ABC,CCC.DD", ".abc" };
    List<string> outputStrings = new List<string>();
    foreach (var s in strings)
    {
        // Scan from right. If find ',' first, no changes, otherwise replace everything found
        bool foundPeriod = false;
        bool foundComma = false;
        bool foundCommaFirst = false;
        string outputString = string.Empty;
        foreach (var character in s.Reverse())
        {
            if (character == '.')
            {
                foundPeriod = true;
            }
            if (character == ',')
            {
                foundComma = true;
            }
            if (!foundComma && foundPeriod)
            {
                foundCommaFirst = true;
            }
            if (foundCommaFirst)
            {
                // This means we need to replace everything with the opposite
                // Create the string backwards then reverse it later to make life easier
                if (character == ',')
                {
                    outputString += ".";
                }
                else if (character == '.')
                {
                    outputString += ",";
                }
                else
                {
                    outputString += character;
                }
            }
            else
            {
                outputString += character;
            }
        }
        // Reverse it
        var charArray = outputString.ToCharArray();
        Array.Reverse(charArray);
        outputString = new string(charArray);
        outputStrings.Add(outputString);
    }
