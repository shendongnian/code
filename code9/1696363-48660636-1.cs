    string[] words = new[] { "Hello", "World", "in", "a", "frame" };
    int height = words.Length + 4;
    int row = 0;
    int column = 0;
    void Write(char c)
    {
        Console.SetCursorPosition(column, row);
        System.Console.Write(c);
    }
    int i = 0;
    int completedWordCount = 0;
    int? lastColumn = null;
    do
    {
        row = i % height;
        column = i / height;
        if (row == 0 || row == height - 1)
        {
            completedWordCount = 0;
            Write('*');
        }
        if (column == 0 || column == lastColumn)
        {
            Write('*');
        }
        if (row > 1 && row < height - 2 && column > 1)
        {
            string word = words[row - 2];
            if (column - 2 < word.Length)
            {
                Write(word[column - 2]);
            }
            else
            {
                completedWordCount++;
            }
            if (completedWordCount == words.Length && !lastColumn.HasValue)
            {
                lastColumn = column + 2;
            }
        }
        i++;
    } while ((!lastColumn.HasValue || column < lastColumn) || row != height - 1);
