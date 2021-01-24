    // Pseudocode
    static void AlternateCharCases(char[] word, int index, List<string> result)
    {
        // This is our recursive "break" condition - we return each time a word is added
        // to the list, NOT just when we have finished compiling the list 
        if (startIndex == len(word))
        {
            AddWordToList(word);
            return; // This goes up 1 level of recursion, NOT necessarily back to the top
        }
        else
        {
            // Keep lowercase for this char and keep traversing:
            AlternateCharCases(word, index + 1, result);
            // Now uppercase this char and keep traversing:
            SetCharToUpper(word, index);
            AlternateCharCases(word, index + 1, result);
        }
    }
