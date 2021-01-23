    public enum CharInsertionResult
    {
        Success,
        NoRoom
    }
    
    public abstract class CharInserter
    {
        internal virtual CharInsertionResult InsertString(string stringToInsert, int xStart, int yStart)
        {
            char[] charsToInsert = stringToInsert.ToCharArray();
            int currentXPosition = xStart;
            int currentYPosition = yStart;
        
            // For each character in the array of charsToInsert,
            for (int i = 0; i < charsToInsert.Length; i++)
            {
                // Check if there is enough room...
                if(isEnoughRoom(xStart, yStart, charsToInsert))
                {
                    SetCharAt(currentXPosition, currentYPosition, charsToInsert[i]);
        
                    if (currentXPosition < xSize - 1)
                    {
                        currentXPosition++;
                    }
                    else
                    {
                        currentXPosition = 0;
                        currentYPosition++;
                    }
                    return CharInsertionResult.Success
                }
                else
                {
                    return CharInsertionResult.NoRoom;
                }
            }
        }
    }
