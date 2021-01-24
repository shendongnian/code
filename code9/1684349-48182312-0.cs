    public int CountCharactersBetweenWords(string totalString, string leftWord, string rightWord, char search)
    {
        // Find the indexes of the end of the left and the start of the right word
        int pFrom = totalString.IndexOf(leftWord) + leftWord.Length;
        int pTo = totalString.LastIndexOf(rightWord);
    
        // Get the substring between the words
        string between = totalString.Substring(pFrom, pTo - pFrom);
    
        // Count the characters that are equal with the character to search for
        return between.Count(c => c == search);
    }
