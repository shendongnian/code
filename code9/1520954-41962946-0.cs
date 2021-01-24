    public static string Column(int number, bool entire = false)
    {
        string columnString = string.Empty;
        decimal columnNumber = number;
        while (columnNumber > 0)
        {
            decimal currentLetterNumber = (columnNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            columnString = currentLetter + columnString;
            columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
        }
        if (entire)
        {
            return columnString + ":" + columnString;
        }
        else
        {
            return columnString;
        }
    }
