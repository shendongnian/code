    static void Main()
    {
        string sentence = "Vazov received his elementary education in hisnative town of Sopoandat Plovdiv. The son of a conservative, well-to-do merchant.";
        int numberOfColumns = int.Parse("20");
        int[] bombs = "1 6 17 2 5 0 15".Split(' ').Select(int.Parse).ToArray();
    
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
                if (bombs.Contains(colIndex) && sentence[sentencePointer] != ' ') // only if it has a character
                    array[rowIndex, colIndex] = '*'; // * represents a bomb
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
                Console.Write(array[rowIndex,colIndex]);
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
