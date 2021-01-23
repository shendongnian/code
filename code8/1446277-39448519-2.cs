    static void Main()
    {
        string sentence = "Well this problem is gonna be a ride.";
        int numberOfColumns = int.Parse("10");
        List<int> bombs = "1 3 7 9".Split(' ').Select(int.Parse).ToList();
        // we need to convert to decimal, otherwise C# will ignore decimal part. 
        //example: 127/20 = 6.35, so we need 7 rows. if we don't convert to decimal we have 6
        // the Ceiling says, always round up. so even 6.1 will be rounded to 7
        int numberOfRows = (int)Math.Ceiling(sentence.Length / Convert.ToDecimal(numberOfColumns));
        char[,] array = new char[numberOfRows, numberOfColumns];
        int sentencePointer = 0;
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < numberOfColumns; colIndex++)
            {
                // if you want to print the grid with the full text, just comment the 3 lines below,
                //and keep only "array[rowIndex, colIndex] = sentence[sentencePointer];"
                if (bombs.Contains(colIndex))
                {
                    if (sentence[sentencePointer] == ' ') // bomb is deactivated
                    {
                        bombs.Remove(colIndex);
                        array[rowIndex, colIndex] = sentence[sentencePointer];
                    }
                    else
                        array[rowIndex, colIndex] = '*'; // * represents a bomb
                }
                else
                    array[rowIndex, colIndex] = sentence[sentencePointer];
                sentencePointer++; // move next character
                if (sentencePointer >= sentence.Length)
                    break; // we reach the end of the sentence.
            }
        }
        PrintGrid(array, numberOfRows, numberOfColumns);
        // just give some space to print the final sentence
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            for (int colIndex = 0; colIndex < numberOfColumns; colIndex++)
            {
                Console.Write(array[rowIndex, colIndex]);
            }
        }
        Console.ReadKey();
    }
    private static void PrintGrid(char[,] array, int numberOfRows, int numberOfColumns)
    {
        Console.WriteLine(new string('-', numberOfColumns * 2));
        for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
        {
            Console.Write("|");
            for (int colIndex = 0; colIndex < numberOfColumns; colIndex++)
            {
                Console.Write(array[rowIndex, colIndex]);
                Console.Write("|");
            }
            Console.WriteLine("");
        }
    }
