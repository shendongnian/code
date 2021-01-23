    // Calculates a code string representing the pattern in a grid 
    // by a string of characters from A to P.
    public static string CalculatePatternSignature(IEnumerable<IEnumerable<int>> grid)
    {
        string result = "";
    
        // Here we remember what number represents what letter in the pattern
        Dictionary<int, char> symbolMap = new Dictionary<int, char>();
    
    
        // Going row by row and then column by column
        // we look at each number from top left to bottom right
        foreach (var row in grid)
        {
            foreach(var cell in row)
            {
                // For each number we try to map it to a letter from
                // A to P (16 different values possible)
                char mappedChar;
    
                // We look whether we have seen the integer value before
                // If yes, we can read its assigned mapped letter from the dictionary
                if (!symbolMap.TryGetValue(cell, out mappedChar))
                {
                    // We haven't seen that integer value before,
                    // so use the next free letter and map the 
                    // value to that letter
                    mappedChar = (char)((byte)'A' + symbolMap.Count());
                    symbolMap.Add(cell, mappedChar);
                    if (symbolMap.Count() > 16)
                    {
                       throw new Exception("We have found more than 16 different values in the grid");
                    }
                }
    
                // Add the mapped letter for the integer value in the current cell
                // to the code string
                result += mappedChar;
            }
        }
    
        return result;
    }
