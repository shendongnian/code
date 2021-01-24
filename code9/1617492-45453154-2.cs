    void replaceStringAtPosition(string filePath, int lineNumber, int StartingCharacterPosition, int replaceWordLength, string replaceWord)
    {
        // Get file content as string array.
        var lines = File.ReadAllLines(filePath);
        var sb = new StringBuilder(lines[lineNumber]);
        if (StartingCharacterPosition > sb.Length - 1) throw new Exception(nameof(StartingCharacterPosition) + " parameter value is greater than line length");
        int numberOfCharactersToRemove = StartingCharacterPosition + replaceWordLength > sb.Length - 1 ? sb.Length - StartingCharacterPosition : replaceWordLength;
        // Replacing string at given position
        sb.Remove(StartingCharacterPosition, numberOfCharactersToRemove);
        sb.Insert(StartingCharacterPosition, replaceWord);
        lines[lineNumber] = sb.ToString();
        // Writing new content to file
        File.WriteAllLines(filePath, lines);
    }
